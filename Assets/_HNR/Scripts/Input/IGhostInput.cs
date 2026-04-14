using UnityEngine;

namespace HNR.Input
{
    /// <summary>
    /// Input provider interface consumed by all ghost/body controllers.
    /// Implementations: LocalGhostInput (keyboard), NetworkGhostInput (PurrNet), AIGhostInput (Behavior Designer).
    /// Game systems never check input source.
    /// </summary>
    public interface IGhostInput
    {
        Vector2 GetMoveDirection();
        bool TryPossess();
        bool TryExitBody();
        bool TryPickupScythe();
        bool TryDropScythe();
        bool TryReap();
        bool TryAttack();
    }
}
