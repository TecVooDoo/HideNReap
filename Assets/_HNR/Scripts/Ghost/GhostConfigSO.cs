using UnityEngine;

namespace HNR.Ghost
{
    /// <summary>
    /// Tuning values for ghost/reaper movement. Drag file into GhostController inspector.
    /// </summary>
    [CreateAssetMenu(fileName = "GhostConfig", menuName = "HNR/Ghost Config")]
    public sealed class GhostConfigSO : ScriptableObject
    {
        [Header("Movement")]
        [Tooltip("Max ghost speed in units/sec")]
        [SerializeField] private float maxSpeed = 8f;

        [Tooltip("Acceleration toward max speed (higher = snappier)")]
        [SerializeField] private float acceleration = 12f;

        [Tooltip("Deceleration when no input (lower = floatier)")]
        [SerializeField] private float deceleration = 4f;

        [Header("Lanes")]
        [Tooltip("Z positions for each depth lane (front to back)")]
        [SerializeField] private float[] lanePositions = new float[] { 0f, -2f, -4f };

        [Tooltip("Time to lerp between lanes")]
        [SerializeField] private float laneSwitchDuration = 0.25f;

        [Header("Possession Cooldown")]
        [Tooltip("Seconds after exiting a body before possession allowed")]
        [SerializeField] private float possessionCooldown = 3f;

        // --- Public accessors ---
        public float MaxSpeed => maxSpeed;
        public float Acceleration => acceleration;
        public float Deceleration => deceleration;
        public float[] LanePositions => lanePositions;
        public float LaneSwitchDuration => laneSwitchDuration;
        public float PossessionCooldown => possessionCooldown;
    }
}