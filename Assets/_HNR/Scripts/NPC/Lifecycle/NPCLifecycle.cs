using System;
using UnityEngine;
using HNR.Core;

namespace HNR.NPC
{
    /// <summary>
    /// NPC lifecycle state machine. Manages Alive -> Dead -> Possessed -> Destroyed transitions.
    /// Handles rot timer (per-body, persists across possessions).
    /// Lives on every NPC body in the scene.
    /// </summary>
    public sealed class NPCLifecycle : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private NPCConfigSO config;

        [Header("Initial State")]
        [Tooltip("Starting state. Graveyard map bodies start Dead with partial rot.")]
        [SerializeField] private NPCLifecycleState initialState = NPCLifecycleState.Alive;

        [Tooltip("Starting rot percentage (0 = fresh, 1 = about to destroy). Only used if initialState is Dead.")]
        [Range(0f, 0.99f)]
        [SerializeField] private float initialRotPercent;

        // --- Events ---
        /// <summary>Fired when state changes. Arg: new state.</summary>
        public event Action<NPCLifecycleState> OnStateChanged;

        /// <summary>Fired when rot crosses a stage threshold. Arg: rot normalized (0-1).</summary>
        public event Action<float> OnRotThresholdCrossed;

        /// <summary>Fired when body is destroyed (rot hit zero or excessive damage).</summary>
        public event Action<NPCLifecycle> OnBodyDestroyed;

        // --- Runtime state ---
        private NPCLifecycleState currentState;
        private float rotTimeRemaining;
        private float rotTimeMax;
        private bool isPossessed;
        private int lastRotStage = -1;

        // --- Public API ---
        public NPCLifecycleState CurrentState => currentState;
        public NPCConfigSO Config => config;
        public float RotNormalized => rotTimeMax > 0f ? 1f - (rotTimeRemaining / rotTimeMax) : 1f;
        public float RotTimeRemaining => rotTimeRemaining;
        public bool IsPossessed => isPossessed;
        public bool IsPossessable => currentState == NPCLifecycleState.Dead && rotTimeRemaining > 0f;

        /// <summary>
        /// Returns the rot stage (0-3) per GDD thresholds:
        /// 0 = Fresh (0-25%), 1 = Decaying (25-50%), 2 = Rotting (50-75%), 3 = Near-death (75-100%)
        /// </summary>
        public int RotStage
        {
            get
            {
                float rot = RotNormalized;
                if (rot < 0.25f) return 0;
                if (rot < 0.50f) return 1;
                if (rot < 0.75f) return 2;
                return 3;
            }
        }

        private void Awake()
        {
            if (config == null)
            {
                Debug.LogError($"[NPCLifecycle] No NPCConfigSO assigned on {gameObject.name}");
                return;
            }

            rotTimeMax = config.FreshKillRotTime;

            switch (initialState)
            {
                case NPCLifecycleState.Alive:
                    EnterAlive();
                    break;

                case NPCLifecycleState.Dead:
                    // Pre-placed dead body (graveyard map)
                    rotTimeRemaining = rotTimeMax * (1f - initialRotPercent);
                    SetState(NPCLifecycleState.Dead);
                    ApplyDeadVisuals();
                    break;

                default:
                    EnterAlive();
                    break;
            }
        }

        private void Update()
        {
            if (config == null)
                return;

            // Rot ticks in Dead and Possessed states
            if (currentState == NPCLifecycleState.Dead || currentState == NPCLifecycleState.Possessed)
            {
                TickRot();
            }
        }

        // ------------------------------------------------------------------
        // State transitions
        // ------------------------------------------------------------------

        /// <summary>
        /// Kill this NPC. Transitions from Alive to Dead.
        /// Called by hazards, possessed players, or other kill sources.
        /// </summary>
        public void Kill()
        {
            if (currentState != NPCLifecycleState.Alive)
                return;

            rotTimeRemaining = rotTimeMax;
            lastRotStage = -1;
            SetState(NPCLifecycleState.Dead);
            ApplyDeadVisuals();
        }

        /// <summary>
        /// A ghost possesses this body. Transitions from Dead to Possessed.
        /// Returns false if body is not possessable.
        /// </summary>
        public bool Possess()
        {
            if (!IsPossessable)
                return false;

            isPossessed = true;
            SetState(NPCLifecycleState.Possessed);
            ApplyPossessedVisuals();
            return true;
        }

        /// <summary>
        /// Ghost exits this body (voluntary or forced by rot/damage).
        /// Transitions from Possessed back to Dead. Body keeps its current rot.
        /// </summary>
        public void Unpossess()
        {
            if (currentState != NPCLifecycleState.Possessed)
                return;

            isPossessed = false;
            SetState(NPCLifecycleState.Dead);
            ApplyDeadVisuals();
        }

        /// <summary>
        /// Apply damage to this body. Reduces rot time directly.
        /// If rot hits zero, body is destroyed and ghost ejected.
        /// </summary>
        public void TakeDamage(float damageAmount)
        {
            if (currentState != NPCLifecycleState.Dead && currentState != NPCLifecycleState.Possessed)
                return;

            float rotLoss = damageAmount * config.DamageToRotConversion;
            rotTimeRemaining = Mathf.Max(0f, rotTimeRemaining - rotLoss);

            if (rotTimeRemaining <= 0f)
                DestroyBody();
        }

        // ------------------------------------------------------------------
        // Rot
        // ------------------------------------------------------------------

        private void TickRot()
        {
            float rate = isPossessed ? config.PossessionRotMultiplier : 1f;
            rotTimeRemaining -= rate * Time.deltaTime;

            // Check rot stage thresholds
            int stage = RotStage;
            if (stage != lastRotStage)
            {
                lastRotStage = stage;
                OnRotThresholdCrossed?.Invoke(RotNormalized);
            }

            if (rotTimeRemaining <= 0f)
            {
                rotTimeRemaining = 0f;
                DestroyBody();
            }
        }

        private void DestroyBody()
        {
            if (currentState == NPCLifecycleState.Destroyed)
                return;

            isPossessed = false;
            SetState(NPCLifecycleState.Destroyed);
            OnBodyDestroyed?.Invoke(this);

            // Body gone -- disable visuals, collider, etc.
            // Ghost ejection is handled by whoever listens to OnBodyDestroyed
            gameObject.SetActive(false);
        }

        // ------------------------------------------------------------------
        // Visuals (placeholder -- will be replaced with real art + blob system)
        // ------------------------------------------------------------------

        private void EnterAlive()
        {
            rotTimeRemaining = 0f;
            SetState(NPCLifecycleState.Alive);
            gameObject.layer = WorldLayer.Living;
        }

        private void ApplyDeadVisuals()
        {
            gameObject.layer = WorldLayer.Living;
            // TODO: Switch to "lying down" pose / ragdoll
            // TODO: Enable supernatural blob child on Supernatural layer
        }

        private void ApplyPossessedVisuals()
        {
            gameObject.layer = WorldLayer.Living;
            // TODO: Switch to "standing" pose, enable player-driven animation
            // Blob child switches to red/purple (occupied)
        }

        // ------------------------------------------------------------------
        // Internal
        // ------------------------------------------------------------------

        private void SetState(NPCLifecycleState newState)
        {
            NPCLifecycleState oldState = currentState;
            currentState = newState;

            if (oldState != newState)
                OnStateChanged?.Invoke(newState);
        }
    }
}
