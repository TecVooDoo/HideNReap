using UnityEngine;
using UnityEngine.InputSystem;

namespace HNR.Input
{
    /// <summary>
    /// Keyboard input provider for local player.
    /// Uses the new Input System's Keyboard/Mouse direct access.
    /// Consumes input and exposes via IGhostInput.
    /// </summary>
    public sealed class LocalGhostInput : MonoBehaviour, IGhostInput
    {
        public Vector2 GetMoveDirection()
        {
            Keyboard kb = Keyboard.current;
            if (kb == null)
                return Vector2.zero;

            float h = 0f;
            float v = 0f;

            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) h += 1f;
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) h -= 1f;
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed) v += 1f;
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed) v -= 1f;

            Vector2 dir = new Vector2(h, v);
            if (dir.sqrMagnitude > 1f)
                dir.Normalize();
            return dir;
        }

        public bool TryPossess()
        {
            Keyboard kb = Keyboard.current;
            return kb != null && kb.eKey.wasPressedThisFrame;
        }

        public bool TryExitBody()
        {
            Keyboard kb = Keyboard.current;
            return kb != null && kb.qKey.wasPressedThisFrame;
        }

        public bool TryPickupScythe()
        {
            Keyboard kb = Keyboard.current;
            return kb != null && kb.fKey.wasPressedThisFrame;
        }

        public bool TryDropScythe()
        {
            Keyboard kb = Keyboard.current;
            return kb != null && kb.gKey.wasPressedThisFrame;
        }

        public bool TryReap()
        {
            Keyboard kb = Keyboard.current;
            return kb != null && kb.rKey.wasPressedThisFrame;
        }

        public bool TryAttack()
        {
            Mouse mouse = Mouse.current;
            return mouse != null && mouse.leftButton.wasPressedThisFrame;
        }
    }
}
