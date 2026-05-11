# Hide 'N Reap -- Dev Reference

**Purpose:** Project-specific architecture, namespaces, folder structure, and HNR-specific deltas. Universal coding standards and session workflow live in the canonical layer; this doc points at them rather than duplicating.

**Last updated:** 2026-05-11
**Version:** 2.0
**Primary session doc:** `HNR_Status.md` (read first, every session).

## Revision History

| Date | Version | Sections affected | Change |
|------|---------|-------------------|--------|
| 2026-04-02 | 1.0 | (initial) | Session 2 mechanics review. Established namespaces, folder structure, IGhostInput interface, two-world rendering plan, NPC/Scythe state machines, event architecture, HNR-specific coding rules, 2.5D setup, AI rules, and session workflow inline. |
| 2026-05-11 | 2.0 | Coding Standards, Refactor Guidelines, Session Workflow | Iter-3.5 adoption: replaced inline universal blocks with canonical pointers (`Canonical/TecVooDoo_CodingStandards.md` + `Canonical/UniversalWorkflow.md`). HNR-specific deltas retained in-line below each pointer. Added this Revision History header per iter-3.5 v1.1 mandatory convention. Net ~80 lines shorter; no project-specific content lost. |

---

## Project Overview

**Genre:** Competitive Multiplayer / Social Deception / Action-Humor
**Engine:** Unity 6 (6000.3.10f1), URP
**Working Path:** `E:\Unity\HideNReap` (standalone)
**HNR Root:** `Assets/_HNR/`

**Core Innovation:** Two overlapping worlds. Ghosts possess the dead and pretend to be alive. The Reaper hunts exposed ghosts but can't touch the living world. Power is a choice -- the scythe and possession are mutually exclusive.

---

## Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| `HNR.Core` | Match state, game events, scythe system, world layer management | Planned |
| `HNR.Input` | Input provider interface, local/network/AI implementations | Planned |
| `HNR.Ghost` | Ghost controller, movement, phasing, possession cooldown | Planned |
| `HNR.Possession` | Possession system, body management, rot, body interaction | Planned |
| `HNR.Reaper` | Reaper state, reap mechanic, scythe drain/respawn | Planned |
| `HNR.NPC` | NPC lifecycle, behavior state machines, hazard deaths | Planned |
| `HNR.Hazard` | Environmental hazard system, random events, NPC kills | Planned |
| `HNR.AI` | AI ghost input provider, tactical decision-making | Planned |
| `HNR.Network` | PurrNet integration, network input provider, state sync | Planned |
| `HNR.UI` | HUD, score, match flow UI | Planned |
| `HNR.Audio` | SFX, music, audio cues | Planned |

---

## Folder Structure

```
Assets/_HNR/
|
+-- Scripts/
|   +-- Core/           -- MatchManager, ScytheSystem, WorldLayerManager, GameEvent
|   +-- Input/          -- IGhostInput, LocalInput, NetworkInput, AIInput
|   +-- Ghost/          -- GhostController, GhostMovement, GhostPhasing, CooldownTimer
|   +-- Possession/     -- PossessionSystem, BodyController, RotSystem
|   +-- Reaper/         -- ReaperController, ReapSystem, ScytheDrain
|   +-- NPC/
|   |   +-- Lifecycle/  -- NPCSpawner, NPCLifecycle (Alive/Dead/Possessed/Destroyed)
|   |   +-- Behaviors/  -- HumanBehavior, DogBehavior, CatBehavior, etc.
|   +-- Hazard/         -- HazardManager, HazardEvent, map-specific hazard types
|   +-- AI/             -- AIGhostBrain, AIReaperBrain, AIBodySelector
|   +-- Network/        -- NetworkInputProvider, StateSync, ScytheSync, BodySync
|   +-- UI/
|   +-- Audio/
|
+-- Art/
|   +-- Characters/     -- Ghost, Reaper models (Assembly Kit)
|   +-- NPCs/           -- Kenney humans, Cute Pet animals
|   +-- Environments/   -- KayKit, Tiny Treats, Halloween props
|   +-- VFX/            -- Rot, death, reap, hazard effects
|   +-- UI/
|
+-- Audio/
|   +-- SFX/
|   +-- Music/
|
+-- Data/
|   +-- NPCs/           -- NPC behavior template SOs
|   +-- Events/         -- GameEvent SOs
|   +-- Scythe/         -- Scythe config SO (drain time, respawn range, recharge duration)
|   +-- Rot/            -- Rot config SO (base rate, possession multiplier, damage conversion)
|   +-- Hazards/        -- Hazard config SOs (frequency, kill radius, map pools)
|   +-- Match/          -- Match config SO (timer, score target, player count, AI count)
|
+-- Prefabs/
+-- Scenes/
+-- Animations/
```

---

## Architecture

### Input Provider Interface (Foundation)

```
IGhostInput
    GetMoveDirection() : Vector2
    TryPossess() : bool
    TryExitBody() : bool
    TryPickupScythe() : bool
    TryDropScythe() : bool
    TryReap() : bool
    TryAttack() : bool          // while possessing a body

Implementations:
    LocalGhostInput             // keyboard/gamepad
    NetworkGhostInput           // PurrNet RPCs
    AIGhostInput                // Behavior Designer Pro
```

Game systems consume `IGhostInput`. They never know or care what's driving it.

### Two-World Visibility

```
World Layers:
    Supernatural    -- ghosts, Reaper, scythe, body blobs (Layer: Supernatural)
    Living          -- NPCs, dead bodies (actual models), possessed bodies, props, hazards (Layer: Living)
    Shared          -- environment geometry, buildings, ground (Layer: Default)

Player State -> Camera Culling:
    Ghost/Reaper    -- sees Supernatural + Shared (ghosts, Reaper, scythe, body BLOBS)
                       sees living world dimly (NPCs walking, environment) but NOT body identity
    Possessed       -- sees Living + Shared only (Supernatural culled entirely)
```

**Dead Body Rendering:**
- In **Living layer**: actual NPC model (human, cat, dog, etc.) lying dead on ground
- In **Supernatural layer**: abstract colored blob. Green = empty, Red = occupied. Size/shape does NOT reveal body type.
- Ghost players must remember body locations from their time in the living world to make informed choices.

Implementation: Each dead body has two visual representations -- the actual model (Living layer) and a blob mesh/shader (Supernatural layer). Camera culling toggles which is visible. Alternatively, a shader that swaps appearance based on a per-client global keyword.

### NPC Lifecycle State Machine

```
    ALIVE                   DEAD                    POSSESSED               DESTROYED
    (walking, behaving) --> (body on ground) -----> (ghost controls) -----> (body gone)
         |                      |                        |                      |
    killed by:             possessable by:          rot ticking:           ghost ejected
    - hazard               - any ghost              - passive decay         to supernatural
    - possessed player     - not in cooldown        - faster while active
    - other NPC            - rot > 0                - damage accelerates
                                                    - rot = 0 -> DESTROYED
```

### Scythe State Machine

```
    AVAILABLE ---------> HELD -----------> DRAINING ---------> RECHARGING ---------> AVAILABLE
    (on ground,          (ghost is         (successful         (off field,            (random
     any ghost           Reaper)           reap, scythe        timer counting)         spawn
     can pick up)                          disappears)                                 location)
         ^                   |
         |                   |
         +-------------------+
         (voluntary drop --
          scythe stays where dropped)
```

### Event Architecture

GameEvent ScriptableObjects (same as all TecVooDoo projects):

```
ScytheSystem
    +--- OnScythePickedUp ---> PlayerState (enter Reaper)
    +--- OnScytheDropped ---> WorldLayer (scythe visible on ground)
    +--- OnScytheDrained ---> PlayerState (Reaper -> Ghost), Timer (start recharge)
    +--- OnScytheRespawn ---> WorldLayer (scythe visible at new location)

PossessionSystem
    +--- OnBodyPossessed ---> WorldLayer (switch to Living visibility)
    +--- OnBodyExited ---> WorldLayer (switch to Supernatural visibility), Cooldown (start)
    +--- OnBodyDestroyed ---> Ghost (ejected), VFX (body destruction)

RotSystem
    +--- OnRotThreshold ---> Audio (warning), VFX (intensify decay)
    +--- OnRotZero ---> PossessionSystem (force eject)

NPCLifecycle
    +--- OnNPCKilled ---> BodyManager (register new dead body)
    +--- OnNPCSpawned ---> NPCManager (add to active pool)

HazardSystem
    +--- OnHazardTriggered ---> VFX (hazard visual), NPCLifecycle (kill NPCs in area)

ReapSystem
    +--- OnReapSuccess ---> ScoreManager (increment), ScytheSystem (drain)

MatchManager
    +--- OnMatchStart ---> All systems (initialize)
    +--- OnMatchEnd ---> UI (show scoreboard)
```

### Design Patterns

1. **Input provider interface** -- `IGhostInput` consumed by all controllers. Swap local/network/AI without touching game logic.
2. **Vanilla ScriptableObject architecture** -- GameEvent/GameEventListener for events. Config SOs for rot, scythe, hazards, match settings, NPC behaviors.
3. **Interface segregation** -- `IPossessable`, `IReapable`, `IDamageable`, `IRotting`
4. **PersistentSingleton** -- TecVooDoo Utilities for MatchManager, WorldLayerManager.
5. **Object pooling** -- for VFX, NPC respawns, hazard effects.
6. **State pattern** -- Ghost, Possessed, Reaper as player states. NPC lifecycle states. Scythe states.

---

## Coding Standards

**Universal TecVooDoo coding standards: see `E:\Unity\Sandbox\Documents\Canonical\TecVooDoo_CodingStandards.md` (canonical).** That file is the single source of truth across all TecVooDoo Unity projects. When it changes, the change shows in its Revision History header.

### HNR-Specific Additions

These are on top of the universal rules; they do not override them.

- **Input-source agnostic** -- game systems consume `IGhostInput`, never check input source. Local / network / AI implementations swap behind the interface.
- **Server-authoritative state** -- scythe ownership, body rot, NPC lifecycle, possession state, reap events. Clients request, server validates and broadcasts. (Activates in Sprint 6 networking pass; design with the constraint now.)
- **Deterministic NPC behavior** -- same seed = same behavior on all clients. No `Random.Range` calls that bypass the seeded RNG.
- **Per-body rot values** -- rot belongs to the body, not the ghost. Persists across possessions. The ghost takes the consequences of what their previous body left behind.
- **World layer discipline** -- every GameObject must be on the correct Unity layer (Supernatural=6, Living=7, Default=Shared). Visibility bugs are game-breaking; treat layer assignment as a first-class concern in every prefab.
- **Config SOs for all tuning values** -- rot rates, hazard frequency, cooldown duration, scythe recharge time. No magic numbers in code. Tunable without recompile.
- **No phase system** -- the game flows continuously. Do NOT introduce phase gates, forced ejections, or artificial state cycling. If tension is lacking, tune the body economy (hazard frequency, rot rates, cooldown timers). See GDD v2.0 history for why the phase system was cut.
- **No mimic/patrol-pattern detection** -- body type determines movement capabilities; detection is between possessed players in the living world reading each other's decisions, not pattern-matching against scripted patrols.
- **No UI detection markers** -- detection is observational, not annotated by the UI.

---

## Refactor Guidelines

**Universal refactor philosophy: see `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md` § Refactor Philosophy (canonical).** Responsibility-driven, line count is a smell not a target, every move needs justification.

No HNR-specific refactor deltas at this time. If one emerges (e.g. networking layer requires a specific split pattern), add it below this pointer.

---

## 2.5D Setup

Same approach as AQS:
- **3D physics** -- Rigidbody + CapsuleCollider, freeze Z rotation
- **Lane-based movement** -- 2-3 depth lanes (Z positions), not free Z movement
- **Cinemachine 2.5D camera** -- fixed side-view framing entire single-screen map
- **Unity 6 API** -- `rb.linearVelocity` not `velocity`

---

## AI Rules

1. **Primary doc:** `HNR_Status.md` -- read first, always.
2. **Working directory:** `E:\Unity\HideNReap`
3. **HNR root:** `Assets/_HNR/`
4. **GDD is user's doc** -- update only when asked.
5. **No phase system** -- do not reintroduce. See GDD v2.0 history.
6. **No mimic system** -- body type determines movement. Detection is player decisions, not patrol pattern matching.
7. **No UI detection markers** -- detection is between possessed players in the living world, not from the Reaper.
8. **Input interface first** -- all controllers consume `IGhostInput`.
9. **Build single-player first** -- network layer comes after gameplay is proven.
10. **All TecVooDoo coding standards apply.**
11. **MCP tools available** -- use for scene setup, component configuration, testing.
12. **Asset evaluations live in Sandbox** -- reference `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md`.

---

## Session Workflow

**Universal session bookends: see `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md` § Session Bookends (canonical).** Start = read Status + scan memory. Close = doc-update checklist (Status, StatusArchive if rolling, CodeReference if structure shifted, DevReference if architecture shifted, memory if a session-spanning lesson emerged) + commit + push + git-status-clean invariant.

### HNR-Specific Session Notes

- **Sprint cadence:** the Status doc tracks current sprint phase and a per-sprint playtest target. When a sprint's playtest target passes, log the result and roll the next sprint's checklist into the Next list.
- **Unity Editor reachability:** verify MCP can reach the Editor (`editor-application-get-state`) at session start before doing scene/asset work. If the Editor isn't running, ask before doing anything that needs it.
- **Push target:** `origin/main` on `https://github.com/TecVooDoo/HideNReap` (pre-authorized).

---

**End of Document**
