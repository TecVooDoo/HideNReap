using UnityEngine;

namespace HNR.NPC
{
    /// <summary>
    /// Per-NPC-type configuration. One SO per type (Human, Dog, Cat, etc.).
    /// Defines rot values, movement capabilities, and body-specific tuning.
    /// </summary>
    [CreateAssetMenu(fileName = "NPCConfig", menuName = "HNR/NPC Config")]
    public sealed class NPCConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private NPCType npcType = NPCType.Human;

        [Header("Rot Timing")]
        [Tooltip("Max rot time in seconds for a fresh kill of this type")]
        [SerializeField] private float freshKillRotTime = 60f;

        [Tooltip("Multiplier on rot rate while body is possessed (1 = same as passive)")]
        [SerializeField] private float possessionRotMultiplier = 2f;

        [Tooltip("How much rot time is removed per point of damage taken")]
        [SerializeField] private float damageToRotConversion = 5f;

        [Header("Movement (When Possessed)")]
        [Tooltip("Walk speed when possessed")]
        [SerializeField] private float moveSpeed = 4f;

        [Tooltip("Can this body type climb (cats, humans)?")]
        [SerializeField] private bool canClimb;

        [Tooltip("Can this body type fly (birds, chickens briefly)?")]
        [SerializeField] private bool canFly;

        [Tooltip("Can this body type burrow (rabbits)?")]
        [SerializeField] private bool canBurrow;

        [Header("Alive Behavior")]
        [Tooltip("Walk speed when NPC is alive (AI-controlled)")]
        [SerializeField] private float aliveWalkSpeed = 2f;

        // --- Public accessors ---
        public NPCType NPCType => npcType;
        public float FreshKillRotTime => freshKillRotTime;
        public float PossessionRotMultiplier => possessionRotMultiplier;
        public float DamageToRotConversion => damageToRotConversion;
        public float MoveSpeed => moveSpeed;
        public bool CanClimb => canClimb;
        public bool CanFly => canFly;
        public bool CanBurrow => canBurrow;
        public float AliveWalkSpeed => aliveWalkSpeed;
    }
}
