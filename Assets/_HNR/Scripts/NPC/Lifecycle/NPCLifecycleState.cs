namespace HNR.NPC
{
    /// <summary>
    /// NPC body states. Matches the GDD lifecycle:
    /// Alive (walking) -> Dead (on ground, possessable) -> Possessed (ghost inside) -> Destroyed (body gone).
    /// </summary>
    public enum NPCLifecycleState
    {
        Alive,
        Dead,
        Possessed,
        Destroyed
    }
}
