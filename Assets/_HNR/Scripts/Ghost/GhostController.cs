using UnityEngine;
using HNR.Core;
using HNR.Input;

namespace HNR.Ghost
{
    /// <summary>
    /// Core ghost controller. Handles floaty supernatural movement, lane switching,
    /// player state transitions, and possession cooldown tracking.
    /// Consumes IGhostInput -- works identically for local, network, and AI players.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class GhostController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GhostConfigSO config;

        [Header("References")]
        [SerializeField] private WorldLayerManager worldLayerManager;

        // --- Runtime state ---
        private IGhostInput input;
        private Rigidbody rb;
        private PlayerState currentState = PlayerState.Ghost;
        private Vector2 currentVelocity;
        private int currentLaneIndex;
        private float possessionCooldownTimer;

        // --- Public API ---
        public PlayerState CurrentState => currentState;
        public bool IsOnCooldown => possessionCooldownTimer > 0f;
        public float CooldownRemaining => possessionCooldownTimer;
        public int CurrentLaneIndex => currentLaneIndex;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            input = GetComponent<IGhostInput>() as IGhostInput;
            if (input == null)
                input = GetComponentInChildren<IGhostInput>() as IGhostInput;

            gameObject.layer = WorldLayer.Supernatural;

            if (config != null && config.LanePositions.Length > 0)
            {
                currentLaneIndex = 0;
                SnapToLane(currentLaneIndex);
            }
        }

        private void Update()
        {
            if (input == null || config == null)
                return;

            // Only process movement in Ghost or Reaper state
            if (currentState == PlayerState.Possessed)
                return;

            UpdateCooldownTimer();
        }

        private void FixedUpdate()
        {
            if (input == null || config == null)
                return;

            if (currentState == PlayerState.Possessed)
                return;

            UpdateFloatyMovement();
        }

        // ------------------------------------------------------------------
        // Movement
        // ------------------------------------------------------------------

        private void UpdateFloatyMovement()
        {
            Vector2 moveInput = input.GetMoveDirection();
            float accel = config.Acceleration;
            float decel = config.Deceleration;
            float maxSpd = config.MaxSpeed;

            // X axis -- accelerate toward input, decelerate toward zero
            if (Mathf.Abs(moveInput.x) > 0.01f)
            {
                currentVelocity.x = Mathf.MoveTowards(
                    currentVelocity.x,
                    moveInput.x * maxSpd,
                    accel * Time.fixedDeltaTime);
            }
            else
            {
                currentVelocity.x = Mathf.MoveTowards(
                    currentVelocity.x,
                    0f,
                    decel * Time.fixedDeltaTime);
            }

            // Y axis -- ghosts float freely up/down
            if (Mathf.Abs(moveInput.y) > 0.01f)
            {
                currentVelocity.y = Mathf.MoveTowards(
                    currentVelocity.y,
                    moveInput.y * maxSpd,
                    accel * Time.fixedDeltaTime);
            }
            else
            {
                currentVelocity.y = Mathf.MoveTowards(
                    currentVelocity.y,
                    0f,
                    decel * Time.fixedDeltaTime);
            }

            // Apply via Rigidbody (Unity 6 API)
            Vector3 vel = rb.linearVelocity;
            vel.x = currentVelocity.x;
            vel.y = currentVelocity.y;
            // Z handled by lane system, not direct input
            rb.linearVelocity = vel;
        }

        // ------------------------------------------------------------------
        // Lane switching (TODO: dedicated keys, not vertical input)
        // ------------------------------------------------------------------

        private void SnapToLane(int laneIndex)
        {
            if (config.LanePositions.Length == 0)
                return;

            Vector3 pos = transform.position;
            pos.z = config.LanePositions[laneIndex];
            transform.position = pos;
        }

        // ------------------------------------------------------------------
        // Cooldown
        // ------------------------------------------------------------------

        private void UpdateCooldownTimer()
        {
            if (possessionCooldownTimer > 0f)
                possessionCooldownTimer = Mathf.Max(0f, possessionCooldownTimer - Time.deltaTime);
        }

        // ------------------------------------------------------------------
        // State transitions (called by external systems)
        // ------------------------------------------------------------------

        /// <summary>
        /// Called by PossessionSystem when ghost enters a dead body.
        /// Disables ghost movement, switches to living layer visibility.
        /// </summary>
        public void EnterPossessedState()
        {
            currentState = PlayerState.Possessed;
            currentVelocity = Vector2.zero;
            rb.linearVelocity = Vector3.zero;

            // Ghost visual hidden, body takes over
            // The body controller handles movement from here
            gameObject.SetActive(false);

            if (worldLayerManager != null)
                worldLayerManager.SetView(PlayerState.Possessed);
        }

        /// <summary>
        /// Called by PossessionSystem when ghost exits a body (voluntary or rot ejection).
        /// Re-enables ghost, starts cooldown, switches to supernatural visibility.
        /// </summary>
        public void ExitPossessedState(Vector3 spawnPosition)
        {
            gameObject.SetActive(true);
            transform.position = spawnPosition;
            currentState = PlayerState.Ghost;
            currentVelocity = Vector2.zero;
            rb.linearVelocity = Vector3.zero;
            possessionCooldownTimer = config.PossessionCooldown;
            gameObject.layer = WorldLayer.Supernatural;

            if (worldLayerManager != null)
                worldLayerManager.SetView(PlayerState.Ghost);
        }

        /// <summary>
        /// Called when ghost picks up the scythe.
        /// </summary>
        public void EnterReaperState()
        {
            currentState = PlayerState.Reaper;

            if (worldLayerManager != null)
                worldLayerManager.SetView(PlayerState.Reaper);
        }

        /// <summary>
        /// Called when Reaper drops the scythe or reap drains it.
        /// </summary>
        public void ExitReaperState()
        {
            currentState = PlayerState.Ghost;

            if (worldLayerManager != null)
                worldLayerManager.SetView(PlayerState.Ghost);
        }

        /// <summary>
        /// Allows external systems to assign an input provider at runtime
        /// (e.g., NetworkGhostInput after spawn, AIGhostInput for bots).
        /// </summary>
        public void SetInputProvider(IGhostInput provider)
        {
            input = provider;
        }
    }
}
