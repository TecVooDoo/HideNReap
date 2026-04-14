using UnityEngine;

namespace HNR.Core
{
    /// <summary>
    /// Clamps any Rigidbody to the camera's visible area.
    /// Attach to any object that should stay on screen (ghosts, NPCs, bodies).
    /// Uses the camera's world-space frustum at a configurable Z depth.
    /// Also zeroes velocity on the clamped axis to prevent floaty bounce-back.
    /// </summary>
    public sealed class ScreenBoundary : MonoBehaviour
    {
        [Header("Config")]
        [Tooltip("Camera to calculate bounds from. Falls back to Camera.main.")]
        [SerializeField] private Camera boundaryCamera;

        [Tooltip("Inset from screen edge in world units (prevents objects clipping at edge)")]
        [SerializeField] private float padding = 0.5f;

        [Tooltip("Clamp vertical (Y) axis. Disable for ground-based objects that use gravity.")]
        [SerializeField] private bool clampVertical = true;

        [Tooltip("Clamp horizontal (X) axis.")]
        [SerializeField] private bool clampHorizontal = true;

        // --- Cached bounds ---
        private float minX;
        private float maxX;
        private float minY;
        private float maxY;
        private Rigidbody rb;
        private bool boundsValid;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (boundaryCamera == null)
                boundaryCamera = Camera.main;

            RecalculateBounds();
        }

        private void FixedUpdate()
        {
            if (!boundsValid || rb == null)
                return;

            Vector3 pos = rb.position;
            Vector3 vel = rb.linearVelocity;
            bool clamped = false;

            if (clampHorizontal)
            {
                if (pos.x < minX)
                {
                    pos.x = minX;
                    vel.x = Mathf.Max(0f, vel.x);
                    clamped = true;
                }
                else if (pos.x > maxX)
                {
                    pos.x = maxX;
                    vel.x = Mathf.Min(0f, vel.x);
                    clamped = true;
                }
            }

            if (clampVertical)
            {
                if (pos.y < minY)
                {
                    pos.y = minY;
                    vel.y = Mathf.Max(0f, vel.y);
                    clamped = true;
                }
                else if (pos.y > maxY)
                {
                    pos.y = maxY;
                    vel.y = Mathf.Min(0f, vel.y);
                    clamped = true;
                }
            }

            if (clamped)
            {
                rb.position = pos;
                rb.linearVelocity = vel;
            }
        }

        /// <summary>
        /// Recalculate screen bounds from the camera. Call if camera moves or FOV changes.
        /// For HNR the camera is fixed, so this only runs once in Start.
        /// </summary>
        public void RecalculateBounds()
        {
            if (boundaryCamera == null)
            {
                boundsValid = false;
                return;
            }

            // Calculate bounds at the object's Z depth (or lane 0 Z for consistency)
            float zDepth = Mathf.Abs(boundaryCamera.transform.position.z - transform.position.z);

            // Perspective camera: use frustum math
            // Orthographic camera: use orthographicSize
            if (boundaryCamera.orthographic)
            {
                float halfHeight = boundaryCamera.orthographicSize;
                float halfWidth = halfHeight * boundaryCamera.aspect;

                Vector3 camPos = boundaryCamera.transform.position;
                minX = camPos.x - halfWidth + padding;
                maxX = camPos.x + halfWidth - padding;
                minY = camPos.y - halfHeight + padding;
                maxY = camPos.y + halfHeight - padding;
            }
            else
            {
                // Perspective: calculate visible rect at object's Z distance
                float halfHeight = zDepth * Mathf.Tan(boundaryCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
                float halfWidth = halfHeight * boundaryCamera.aspect;

                Vector3 camPos = boundaryCamera.transform.position;
                minX = camPos.x - halfWidth + padding;
                maxX = camPos.x + halfWidth - padding;
                minY = camPos.y - halfHeight + padding;
                maxY = camPos.y + halfHeight - padding;
            }

            boundsValid = true;
        }

        /// <summary>
        /// Returns true if the given world position is within screen bounds.
        /// Useful for NPC spawning checks.
        /// </summary>
        public bool IsWithinBounds(Vector3 worldPosition)
        {
            if (!boundsValid)
                return true;

            return worldPosition.x >= minX && worldPosition.x <= maxX
                && worldPosition.y >= minY && worldPosition.y <= maxY;
        }

        /// <summary>
        /// Returns the current screen bounds as a Rect (minX, minY, width, height).
        /// </summary>
        public Rect GetBoundsRect()
        {
            return new Rect(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
