# Hide 'N Reap -- Code Reference

**Purpose:** Script inventory and API reference for HNR.
**Last Updated:** April 2, 2026 (Session 3 -- Sprint 1 Foundation)

---

## Implemented Scripts

### HNR.Core

| Script | Path | Purpose |
|--------|------|---------|
| PlayerState | `Scripts/Core/PlayerState.cs` | Enum: Ghost, Possessed, Reaper |
| WorldLayer | `Scripts/Core/WorldLayer.cs` | Layer constants (Supernatural=6, Living=7), camera culling masks |
| WorldLayerManager | `Scripts/Core/WorldLayerManager.cs` | Camera culling mask toggle based on player state |
| ScreenBoundary | `Scripts/Core/ScreenBoundary.cs` | Clamps rigidbody to camera viewport (ortho + perspective) |

### HNR.Input

| Script | Path | Purpose |
|--------|------|---------|
| IGhostInput | `Scripts/Input/IGhostInput.cs` | Interface: GetMoveDirection, TryPossess, TryExitBody, TryPickupScythe, TryDropScythe, TryReap, TryAttack |
| LocalGhostInput | `Scripts/Input/LocalGhostInput.cs` | Keyboard input: WASD move, E possess, Q exit, F/G scythe, R reap, LMB attack |

### HNR.Ghost

| Script | Path | Purpose |
|--------|------|---------|
| GhostConfigSO | `Scripts/Ghost/GhostConfigSO.cs` | SO: maxSpeed(8), accel(12), decel(4), lane positions, possession cooldown(3s) |
| GhostController | `Scripts/Ghost/GhostController.cs` | Floaty X/Y movement, state transitions, cooldown timer, WorldLayerManager integration |

**GhostController API:**
- `EnterPossessedState()` -- hides ghost, switches camera to living layer
- `ExitPossessedState(Vector3 spawnPos)` -- reappears ghost, starts cooldown, switches camera back
- `EnterReaperState()` / `ExitReaperState()` -- scythe state transitions
- `SetInputProvider(IGhostInput)` -- runtime input swap (network, AI)
- `IsOnCooldown`, `CooldownRemaining`, `CurrentState` -- read-only state

### HNR.NPC

| Script | Path | Purpose |
|--------|------|---------|
| NPCLifecycleState | `Scripts/NPC/Lifecycle/NPCLifecycleState.cs` | Enum: Alive, Dead, Possessed, Destroyed |
| NPCType | `Scripts/NPC/Lifecycle/NPCType.cs` | Enum: Human, Dog, Cat, Pig, Sheep, Chicken, Bird, Rabbit |
| NPCConfigSO | `Scripts/NPC/Lifecycle/NPCConfigSO.cs` | SO: rot timing, movement caps (speed, canClimb, canFly, canBurrow), alive walk speed |
| NPCLifecycle | `Scripts/NPC/Lifecycle/NPCLifecycle.cs` | State machine: Alive->Dead->Possessed->Destroyed. Rot timer with 4 stages. |

**NPCLifecycle API:**
- `Kill()` -- Alive->Dead, starts rot timer
- `Possess()` -> bool -- Dead->Possessed if possessable
- `Unpossess()` -- Possessed->Dead, body keeps rot
- `TakeDamage(float)` -- reduces rot time, destroys at zero
- `IsPossessable` -- true if Dead and rot > 0
- `RotStage` (0-3), `RotNormalized` (0-1), `RotTimeRemaining`
- Events: `OnStateChanged`, `OnRotThresholdCrossed`, `OnBodyDestroyed`

### HNR.Possession

| Script | Path | Purpose |
|--------|------|---------|
| PossessionSystem | `Scripts/Possession/PossessionSystem.cs` | Bridges GhostController + NPCLifecycle. OverlapSphere body detection, exit via event. |
| BodyController | `Scripts/Possession/BodyController.cs` | Possessed body movement (horizontal only), stand-up/lie-down, exit input (Q key). |

**PossessionSystem API:**
- `ExitBody()` -- voluntary exit, deactivates body, reappears ghost
- `CurrentBody`, `IsInBody` -- read-only state
- `SetInputProvider(IGhostInput)` -- runtime input swap

**BodyController API:**
- `Activate(IGhostInput, NPCConfigSO)` -- starts body movement, stands up
- `Deactivate()` -- stops movement, lies down
- Event: `OnExitRequested` -- fired when Q pressed

---

## SO Assets

| Asset | Path | Purpose |
|-------|------|---------|
| GhostConfig | `Data/GhostConfig.asset` | Ghost movement tuning |
| NPCConfig_Human | `Data/NPCConfig_Human.asset` | Human NPC type config (default values) |

---

## Scenes

| Scene | Path | Purpose |
|-------|------|---------|
| HNR_GraveyardTest | `Scenes/HNR_GraveyardTest.unity` | Sprint 1 test scene: fixed camera, ghost, 3 dead bodies |

---

## Planned Scripts (Not Yet Implemented)

### HNR.Core
- MatchManager, ScytheSystem, GameEvent/GameEventListener

### HNR.Reaper
- ReaperController, ReapSystem, ScytheDrain

### HNR.NPC
- NPCSpawner, NPC behavior scripts (per-type), BodyTypeMovement

### HNR.Hazard
- HazardManager, HazardEvent subtypes

### HNR.AI
- AIGhostInput, AIGhostBrain, AIReaperBrain, AIBodySelector

### HNR.Network
- NetworkGhostInput, StateSync, BodySync

### HNR.UI / HNR.Audio
- ScoreHUD, MatchTimerUI, RotWarningUI, AudioCueManager

---

**End of Document**
