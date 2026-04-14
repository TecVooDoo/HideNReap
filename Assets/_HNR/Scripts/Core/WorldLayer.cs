namespace HNR.Core
{
    /// <summary>
    /// Unity layer indices for the two-world system.
    /// Must match layers defined in Tags and Layers settings.
    /// Supernatural: ghosts, Reaper, scythe, body blobs
    /// Living: NPCs, dead bodies (actual models), possessed bodies, props, hazards
    /// Default (0): shared environment geometry
    /// </summary>
    public static class WorldLayer
    {
        // Unity built-in
        public const int Default = 0;

        // Custom layers -- set these up in Project Settings > Tags and Layers
        // Using layers 6 and 7 (first available user layers in Unity)
        public const int Supernatural = 6;
        public const int Living = 7;

        // Layer masks for camera culling
        public static readonly int MaskGhostView = (1 << Default) | (1 << Supernatural) | (1 << Living);
        public static readonly int MaskPossessedView = (1 << Default) | (1 << Living);
    }
}
