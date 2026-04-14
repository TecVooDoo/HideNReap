# Hide 'N Reap -- Project Status

**Project:** Hide 'N Reap (2.5D Competitive Multiplayer / Social Deception)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Working Path:** `E:\Unity\HideNReap` (standalone)
**HNR Root:** `Assets/_HNR/`
**Last Updated:** April 13, 2026 (Session 4 -- Standalone Setup + Scene Rebuild)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `HNR_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `HNR_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 1 in progress. Standalone project fully set up. Scene rebuilt, core loop playable. Stand-up physics fix applied, needs retest.

**Session 4 (Apr 13, 2026) -- Standalone Setup + Scene Rebuild:**
- Migrated to standalone project at `E:\Unity\HideNReap` (was prototyped in Sandbox)
- Git initialized, initial commit pushed to `https://github.com/TecVooDoo/HideNReap` (branch: main)
- .gitignore set up: tracks only `_HNR/`, project config, docs. Excludes all third-party assets.
- MCP configured: port 26876, `.mcp.json` + `.claude/mcp.json` + `.vscode/mcp.json` all wired up
- Added HideNReap to MCP_ConnectionBrief.md port registry
- Set up Unity layers: 6=Supernatural, 7=Living (via script-execute)
- Created GhostConfig.asset + NPCConfig_Human.asset ScriptableObjects
- Rebuilt HNR_GraveyardTest scene from scratch (blank scene after migration):
  - Main Camera at (0,2,-15), perspective FOV 40, WorldLayerManager component
  - Ground (dark green cube, 20x1x10)
  - GhostPlayer (cyan capsule, layer=Supernatural) with LocalGhostInput, GhostController, PossessionSystem, ScreenBoundary
  - 3 dead bodies (DeadBody_Fresh 10%, DeadBody_Decaying 40%, DeadBody_Rotting 70%) with Rigidbodies and NPCLifecycle
- Rewrote LocalGhostInput: old `UnityEngine.Input` API -> new Input System (`Keyboard.current`/`Mouse.current`)
- Fixed BodyController stand-up physics: use `rb.position`/`rb.rotation` instead of `transform` to prevent physics override. Clear velocity before repositioning.
- **Playtest results:** Ghost WASD movement works (floaty feel). E/Q possess/exit works. Body moves left/right when possessed. Stand-up was intermittent before fix -- needs retest.
- **Compile times:** Fast! Standalone project compiles in seconds vs 10-15 min in Sandbox. Migration was the right call.

**Session 3 (Apr 2, 2026) -- Sprint 1 Foundation:**
- All 14 scripts written (Core, Input, Ghost, NPC, Possession) -- see CodeReference.md
- Scene was built in Sandbox but did not transfer to standalone (scene file was blank)
- Scripts transferred fine -- all compile clean

**Next (Session 5 -- Finish Sprint 1):**
- Retest stand-up/lie-down with physics fix (should be consistent now)
- Verify possession cooldown (3s timer visible in inspector)
- Verify rot timer ticking (rotting body should disappear, eject ghost)
- Verify screen boundary clamping
- If all Sprint 1 items pass: commit and plan Sprint 2 (Scythe + Rot economy)

**Sprint Plan (Single-Player First, Network Last):**

### Sprint 1: Foundation (Local, Primitives)
- IGhostInput interface + LocalGhostInput implementation
- World layer system (camera culling mask toggle on state change)
- Ghost controller + movement (2.5D lane-based, phasing, uses IGhostInput)
- NPC spawner + lifecycle state machine (Alive -> Dead -> Possessed -> Destroyed)
- Possession system (enter/exit dead body, cooldown timer)
- Graveyard test map (primitives -- cubes/capsules, pre-placed bodies at various rot)
- **Playtest:** Move as ghost, possess body, see world layer switch, exit, feel cooldown

### Sprint 2: Scythe + Rot (The Economy)
- Rot system (per-body timer, persists across possessions, damage acceleration, visual decay)
- Scythe system (pickup/drop/drain/recharge/random respawn)
- Reaper state (can see ghosts, reap exposed ghosts, can't possess, can't interact)
- Possessed body interaction (attack other bodies, kill living NPCs -> create fresh bodies)
- Config SOs for all tuning values (rot rates, scythe timers, cooldown duration)
- **Playtest:** Full tactical loop with one player swapping roles. Body economy feel check.

### Sprint 3: NPC Behavior + Hazards (The Deception)
- NPC behavior trees (Behavior Designer Pro -- living NPC patterns, NOT player mimic)
- Body-type movement (body determines capabilities: climb, fly, burrow, etc.)
- Environmental hazard system (1-2 types, random timing, NPC area kills)
- Possessed player detection (aggression, unnatural stillness, rot visuals)
- Possessed player combat (attack other bodies, kill NPCs)
- **Playtest:** Can possessed players spot each other? Does body-type movement feel right?

### Sprint 4: AI Opponents (Single-Player Complete)
- AIGhostInput (implements IGhostInput, driven by Behavior Designer Pro)
- AI ghost behavior (find bodies, evaluate rot, possess, act naturally, attack strategically)
- AI Reaper behavior (hunt exposed ghosts, drop-possess-chaos-reap loop)
- Match flow (start, timer, scoring, end screen)
- Difficulty tuning
- **Playtest:** Full single-player game. 1 human vs 2-3 AI ghosts. Is it fun?

### Sprint 5: Art Pass + Second Map
- Swap primitives for real art (Kenney, Cute Pet, Assembly Kit, KayKit)
- City Street map (zero starting bodies, hazard-dependent economy)
- Audio cues (death, scythe, reap, rot warnings, hazard warnings)
- Rot VFX (progressive visual decay)
- **Playtest:** Does it look/feel like a game? City Street vs Graveyard feel different?

### Sprint 6: Networking (PurrNet)
- NetworkGhostInput (implements IGhostInput, PurrNet RPCs)
- Server-authoritative state sync (scythe, rot, NPC lifecycle, possession)
- AI players on host
- Purr Transport relay (lobby, room creation, player count + AI fill)
- Per-client world layer rendering
- **Playtest:** 2-player test over relay. Same feel as local?

### Sprint 7: Playable Prototype
- 3-4 player mixed (human + AI) testing
- Barnyard map
- Final tuning pass
- Evaluate standalone migration

---

## Key Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Camera | 2.5D single screen | Lane-based design, full playfield visibility for observation-based detection |
| Networking | PurrNet 1.19.1 (ENTRY-260) | Per-component ownership, built-in relay, awaitable RPCs |
| NPC AI | Behavior Designer Pro (state machines) | Already evaluated, TMCP tools built, simple patterns |
| Art style | Bright cartoon horror (multi-pack) | See Art Direction below |
| Core mechanic | Possess the dead (original design) | Emergent body economy replaces artificial phase system |
| World model | Two overlapping worlds | Supernatural (ghosts/Reaper/scythe) + Living (NPCs/bodies/props) |
| Scythe economy | Drain on reap, random respawn | Prevents Reaper camping, forces regular state transitions |
| Scope | Prototype in Sandbox, migrate when proven | New bootstrap approach -- on-demand assets only |

---

## Art Direction (Session 1 -- Apr 2, 2026)

Evaluated KayKit, Kenney, Tiny Treats, Cute Pet (Suriyun), Assembly Kit (Sigmoid) in a visual lineup scene (`Assets/_Sandbox/_HNR/ArtEval/`). Multi-pack strategy confirmed -- distinct roles per pack prevent style clash and add to the overall aesthetic.

| Role | Pack | Notes |
|------|------|-------|
| **Human NPCs** | Kenney Animated Characters (Medium) | Smooth shading pairs with Cute Pet. Scale 1. Medium only -- Large clashes. |
| **Child NPCs** | Kenney Animated Characters (Small) | Scale 0.5. Same UV/skins as Medium. |
| **Animals** | Cute Pet (Suriyun) | Smooth chibi style. Scale ~5x to match Kenney characters. |
| **Reaper / Ghost** | Assembly Kit (Sigmoid / ForActionGames) | Perfect style match with Cute Pet. Same scale. Has Reaper with scythe + Ghost built in. |
| **Buildings / Environment** | KayKit + Tiny Treats (Isa Lousberg) | Chunky atlas style. Tiny Treats scale ~0.3x to match KayKit. |
| **Horror props** | KayKit Halloween | Gravestones, coffins, skull posts. |
| **Items / Pickups** | Assembly Kit (Sigmoid) | Sword, key, bomb, treasure, etc. Smooth style matches characters. |
| **Scythe** | KayKit Skeletons | Skeleton_Scythe.fbx. Atlas textured. |

**Rejected:** Kenney Graveyard Kit (blocky/voxel). Kenney Large characters (proportion clash). KayKit characters as NPCs (atlas clash with Cute Pet).

**Skin library:** Kenney Bundle has 50+ skins -- all work on both Medium and Small meshes.

---

## Asset Needs

| Need | Decision | Status |
|------|----------|--------|
| Netcode | PurrNet 1.19.1 (ENTRY-260) | RESOLVED -- Session 1. **PENDING: hands-on prototype + TMCP eval (see below)** |
| Character models | Kenney Animated Characters (Medium + Small) | RESOLVED -- Session 1 |
| Animals | Cute Pet (Suriyun) -- already installed | RESOLVED -- Session 1 |
| Reaper / Ghost | Assembly Kit (ForActionGames) -- already installed | RESOLVED -- Session 1 |
| Environment | KayKit + Tiny Treats (CC0, external) | RESOLVED -- Session 1 |
| Horror props | KayKit Halloween (CC0, external) | RESOLVED -- Session 1 |
| Items / Pickups | Assembly Kit (ForActionGames) | RESOLVED -- Session 1 |
| Scythe model | KayKit Skeletons pack (Skeleton_Scythe.fbx) | RESOLVED -- Session 1 |
| Ghost VFX / supernatural layer | OccaSoftware Ghost Shader (ENTRY-315), VFX Library | Sprint 1 -- TBD |
| Rot VFX | Shader-based decay, particle effects | Sprint 2 -- TBD |
| NPC AI | Behavior Designer Pro 3 (ENTRY-229, already eval'd) | Sprint 2 -- TBD |
| Map tileset / ProBuilder | ProBuilder (already in Sandbox) | Sprint 1 -- TBD |

---

## Deferred Evals

| Eval | Type | When | Notes |
|------|------|------|-------|
| PurrNet hands-on prototype | Asset eval (ENTRY-260) | Before Sprint 6 (Networking) | Desk review done (Approved). Need: 2-player host/client, sync position/animation via NetworkBones, test SyncInput latency. Build in HNR standalone. |
| PurrNet TMCP eval | MCP candidate | Before Sprint 6 | Not evaluated for MCP controllability. Test component-add/get/modify for NetworkIdentity, NetworkBones, SyncInput. File in Sandbox_AssetLog.md MCP Candidates section. |

---

## Known Issues

| Issue | Impact | Notes |
|-------|--------|-------|
| Test scene bodies missing Rigidbodies | Scene not fully testable | Bodies need RBs for stand-up/lie-down physics. Quick fix next session. |
| Body stand-up Y position | Capsule embeds in ground at Y=0.5 | Code raises to Y=1 on possess, untested. |

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `Documents\HideNReap\HNR_DevReference.md` |
| Code Reference | `Documents\HideNReap\HNR_CodeReference.md` |
| GDD | `Documents\HideNReap\GDD\HNR_GDD.md` (v2.0) |

---

**End of Document**
