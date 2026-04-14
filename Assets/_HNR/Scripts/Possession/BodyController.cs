using System;
using UnityEngine;
using HNR.Core;
using HNR.Input;
using HNR.NPC;

namespace HNR.Possession
{
    /// <summary>
    /// Controls a possessed body. Added/enabled by PossessionSystem when a ghost enters a body.
    /// Handles ground-based movement using the body's NPCConfig speed.
    /// Bodies use gravity and walk on the ground (unlike ghosts which float).
    /// Also handles exit-body input (Q key) since the ghost GO is disabled during possession.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class BodyController : MonoBehaviour
    {
        // Set by PossessionSystem when possession starts
        private IGhostInput input;
        private NPCConfigSO config;
        private Rigidbody rb;
        private bool isActive;

        /// <summary>Fired when player requests to exit this body (Q key).</summary>
        public event Action OnExitRequested;

        public bool IsActive => isActive;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Called by PossessionSystem when a ghost enters this body.
        /// </summary>
        public void Activate(IGhostInput inputProvider, NPCConfigSO npcConfig)
        {
            input = inputProvider;
            config = npcConfig;
            isActive = true;

            // Clear constraints and velocity so position/rotation can be applied cleanly
            rb.constraints = RigidbodyConstraints.None;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Stand up: raise Y so capsule isn't embedded in ground
            // Capsule is 2 units tall, center needs to be at Y=1 to clear the ground
            CapsuleCollider cap = GetComponent<CapsuleCollider>();
            float halfHeight = cap != null ? cap.height * 0.5f * transform.lossyScale.y : 1f;
            Vector3 pos = transform.position;
            pos.y = halfHeight;

            // Use rb.position/rotation so physics respects the change immediately
            rb.position = pos;
            rb.rotation = Quaternion.identity;
            transform.position = pos;
            transform.rotation = Quaternion.identity;

            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }

        /// <summary>
        /// Called by PossessionSystem when ghost exits this body.
        /// </summary>
        public void Deactivate()
        {
            isActive = false;
            input = null;
            config = null;

            // Body drops -- lie down, gravity settles it
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
            Quaternion lieDown = Quaternion.Euler(0f, 0f, 90f);
            rb.rotation = lieDown;
            transform.rotation = lieDown;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            // Keep gravity and dynamic rigidbody -- physics settles the body naturally
        }

        private void Update()
        {
            if (!isActive || input == null)
                return;

            // Exit body input lives here because the ghost GO is disabled during possession
            if (input.TryExitBody())
                OnExitRequested?.Invoke();
        }

        private void FixedUpdate()
        {
            if (!isActive || input == null || config == null)
                return;

            Vector2 moveInput = input.GetMoveDirection();
            float speed = config.MoveSpeed;

            // Bodies only move horizontally (X axis), no floating
            Vector3 vel = rb.linearVelocity;
            vel.x = moveInput.x * speed;
            // Keep existing Y velocity (gravity)
            rb.linearVelocity = vel;
        }
    }
}
