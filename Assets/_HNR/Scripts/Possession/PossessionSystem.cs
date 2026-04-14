using UnityEngine;
using HNR.Core;
using HNR.Ghost;
using HNR.Input;
using HNR.NPC;

namespace HNR.Possession
{
    /// <summary>
    /// Bridges GhostController and NPCLifecycle. Lives on the ghost/player GO.
    /// Handles: finding nearby bodies, entering/exiting possession, forced ejection.
    /// Consumes IGhostInput for possess/exit commands.
    /// </summary>
    public sealed class PossessionSystem : MonoBehaviour
    {
        [Header("Config")]
        [Tooltip("Max distance to detect possessable bodies")]
        [SerializeField] private float possessRange = 2f;

        [Tooltip("Layer mask for dead bodies (Living layer)")]
        [SerializeField] private LayerMask bodyLayerMask = 1 << WorldLayer.Living;

        [Header("References")]
        [SerializeField] private GhostController ghostController;

        // --- Runtime state ---
        private IGhostInput input;
        private NPCLifecycle currentBody;
        private Collider[] overlapResults = new Collider[16];

        // --- Public API ---
        public NPCLifecycle CurrentBody => currentBody;
        public bool IsInBody => currentBody != null;

        private void Awake()
        {
            if (ghostController == null)
                ghostController = GetComponent<GhostController>();

            input = GetComponent<IGhostInput>() as IGhostInput;
            if (input == null)
                input = GetComponentInChildren<IGhostInput>() as IGhostInput;
        }

        private void Update()
        {
            if (input == null || ghostController == null)
                return;

            // Only handle possess input here. Exit input is handled by BodyController
            // because this GO is disabled during possession.
            if (ghostController.CurrentState == PlayerState.Ghost)
            {
                if (input.TryPossess() && !ghostController.IsOnCooldown)
                    TryPossessNearest();
            }
        }

        // ------------------------------------------------------------------
        // Possession
        // ------------------------------------------------------------------

        private void TryPossessNearest()
        {
            NPCLifecycle nearest = FindNearestPossessableBody();
            if (nearest == null)
                return;

            if (!nearest.Possess())
                return;

            currentBody = nearest;

            // Listen for forced ejection (rot destroy)
            currentBody.OnBodyDestroyed += HandleBodyDestroyed;

            // Add or enable BodyController on the body so the player can move it
            BodyController bodyCtrl = nearest.GetComponent<BodyController>();
            if (bodyCtrl == null)
                bodyCtrl = nearest.gameObject.AddComponent<BodyController>();

            bodyCtrl.OnExitRequested += HandleExitRequested;
            bodyCtrl.Activate(input, nearest.Config);

            // Tell ghost controller to hide and switch camera to living layer
            ghostController.EnterPossessedState();
        }

        private void HandleExitRequested()
        {
            ExitBody();
        }

        /// <summary>
        /// Voluntary exit. Ghost leaves the body, cooldown starts.
        /// </summary>
        public void ExitBody()
        {
            if (currentBody == null)
                return;

            Vector3 exitPosition = currentBody.transform.position;

            // Deactivate body movement and unsubscribe exit event
            BodyController bodyCtrl = currentBody.GetComponent<BodyController>();
            if (bodyCtrl != null)
            {
                bodyCtrl.OnExitRequested -= HandleExitRequested;
                bodyCtrl.Deactivate();
            }

            // Unsubscribe before unpossess
            currentBody.OnBodyDestroyed -= HandleBodyDestroyed;
            currentBody.Unpossess();
            currentBody = null;

            // Ghost reappears at body position
            ghostController.ExitPossessedState(exitPosition);
        }

        // ------------------------------------------------------------------
        // Forced ejection
        // ------------------------------------------------------------------

        private void HandleBodyDestroyed(NPCLifecycle destroyedBody)
        {
            if (destroyedBody != currentBody)
                return;

            Vector3 exitPosition = destroyedBody.transform.position;

            // Deactivate body movement before destroy
            BodyController bodyCtrl = destroyedBody.GetComponent<BodyController>();
            if (bodyCtrl != null)
            {
                bodyCtrl.OnExitRequested -= HandleExitRequested;
                bodyCtrl.Deactivate();
            }

            destroyedBody.OnBodyDestroyed -= HandleBodyDestroyed;
            currentBody = null;

            // Ghost ejected -- same as exit but body is gone
            ghostController.ExitPossessedState(exitPosition);
        }

        // ------------------------------------------------------------------
        // Body detection
        // ------------------------------------------------------------------

        private NPCLifecycle FindNearestPossessableBody()
        {
            int hitCount = Physics.OverlapSphereNonAlloc(
                transform.position,
                possessRange,
                overlapResults,
                bodyLayerMask);

            NPCLifecycle nearest = null;
            float nearestDist = float.MaxValue;

            for (int i = 0; i < hitCount; i++)
            {
                NPCLifecycle lifecycle = overlapResults[i].GetComponent<NPCLifecycle>();
                if (lifecycle == null)
                    continue;

                if (!lifecycle.IsPossessable)
                    continue;

                float dist = Vector3.Distance(transform.position, lifecycle.transform.position);
                if (dist < nearestDist)
                {
                    nearestDist = dist;
                    nearest = lifecycle;
                }
            }

            return nearest;
        }

        /// <summary>
        /// Allows external systems to assign an input provider at runtime.
        /// </summary>
        public void SetInputProvider(IGhostInput provider)
        {
            input = provider;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, possessRange);
        }
    }
}
