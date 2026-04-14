using UnityEngine;

namespace HNR.Input
{
    /// <summary>
    /// Keyboard/gamepad input provider for local player.
    /// Consumes Unity's Input system and exposes via IGhostInput.
    /// </summary>
    public sealed class LocalGhostInput : MonoBehaviour, IGhostInput
    {
        [Header("Movement")]
        [SerializeField] private string horizontalAxis = "Horizontal";
        [SerializeField] private string verticalAxis = "Vertical";

        [Header("Actions")]
        [SerializeField] private KeyCode possessKey = KeyCode.E;
        [SerializeField] private KeyCode exitBodyKey = KeyCode.Q;
        [SerializeField] private KeyCode pickupScytheKey = KeyCode.F;
        [SerializeField] private KeyCode dropScytheKey = KeyCode.G;
        [SerializeField] private KeyCode reapKey = KeyCode.R;
        [SerializeField] private KeyCode attackKey = KeyCode.Mouse0;

        public Vector2 GetMoveDirection()
        {
            float h = UnityEngine.Input.GetAxisRaw(horizontalAxis);
            float v = UnityEngine.Input.GetAxisRaw(verticalAxis);
            Vector2 dir = new Vector2(h, v);
            if (dir.sqrMagnitude > 1f)
                dir.Normalize();
            return dir;
        }

        public bool TryPossess()
        {
            return UnityEngine.Input.GetKeyDown(possessKey);
        }

        public bool TryExitBody()
        {
            return UnityEngine.Input.GetKeyDown(exitBodyKey);
        }

        public bool TryPickupScythe()
        {
            return UnityEngine.Input.GetKeyDown(pickupScytheKey);
        }

        public bool TryDropScythe()
        {
            return UnityEngine.Input.GetKeyDown(dropScytheKey);
        }

        public bool TryReap()
        {
            return UnityEngine.Input.GetKeyDown(reapKey);
        }

        public bool TryAttack()
        {
            return UnityEngine.Input.GetKeyDown(attackKey);
        }
    }
}
