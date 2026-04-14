using UnityEngine;

namespace HNR.Core
{
    /// <summary>
    /// Manages camera culling mask based on local player's current state.
    /// Ghost/Reaper: sees supernatural + living + shared (all layers).
    /// Possessed: sees living + shared only (supernatural hidden).
    /// Attach to the main camera or call SetView from the player controller.
    /// </summary>
    public sealed class WorldLayerManager : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;

        private PlayerState currentView = PlayerState.Ghost;

        public PlayerState CurrentView => currentView;

        private void Awake()
        {
            if (targetCamera == null)
                targetCamera = Camera.main;

            SetView(PlayerState.Ghost);
        }

        public void SetView(PlayerState state)
        {
            currentView = state;

            if (targetCamera == null)
                return;

            switch (state)
            {
                case PlayerState.Ghost:
                case PlayerState.Reaper:
                    targetCamera.cullingMask = WorldLayer.MaskGhostView;
                    break;

                case PlayerState.Possessed:
                    targetCamera.cullingMask = WorldLayer.MaskPossessedView;
                    break;
            }
        }
    }
}
