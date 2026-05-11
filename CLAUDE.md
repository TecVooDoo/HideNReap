# Hide 'N Reap -- Claude Project Index

**Project:** Hide 'N Reap (2.5D possess-the-dead social-deception game).
**Working directory:** `E:\Unity\HideNReap`
**Remote:** `https://github.com/TecVooDoo/HideNReap` (branch `main`, pre-authorized push)
**HNR root in project:** `Assets/_HNR/`
**MCP port:** `26876` (streamableHttp)

This file is the ~50-line pointer index for Claude sessions opened in this project. Read top-down at session start; chase the pointers as needed.

---

## Session bookends (auto-fired)

- **Start:** read `Documents/HNR_Status.md`, scan auto-loaded `MEMORY.md`. Don't ask "what are we working on?" -- Status is the answer.
- **Close:** doc-update checklist (Status, StatusArchive if rolling, CodeReference / DevReference if affected, memory if a session-spanning lesson emerged), commit + push, end with `git status` clean.

Full spec: `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md` § Session Bookends.

---

## Per-project docs

| Doc | Path | When to read |
|-----|------|--------------|
| Status (PRIMARY) | `Documents/HNR_Status.md` | Every session, first thing. Current state + last ~2 sessions + Next list + key decisions + art direction + known issues. |
| Status Archive | `Documents/HNR_StatusArchive.md` | On demand for historical session context older than the most recent ~2 in Status. |
| Dev Reference | `Documents/HNR_DevReference.md` | When you need namespaces, folder structure, IGhostInput interface, two-world rendering, NPC/Scythe state machines, or HNR-specific deltas on top of the canonical coding standards. |
| Code Reference | `Documents/HNR_CodeReference.md` | When you need to know what scripts exist, their public API, or what's still planned. Has Revision History header -- scan for new rows before relying on cached state. |
| GDD | `Documents/GDD/HNR_GDD.md` | When you need design intent. **User-owned** -- read but do not edit unless explicitly asked. |
| Concept art | `Documents/GDD/HnR_Living_World.PNG`, `HnR_Supernatural_World.PNG`, `Hide_n_Reap_Concept.PNG` | Visual reference for the two-world rendering. |

---

## Canonical references (fleet-shared)

| Concern | Canonical file | Read when |
|---------|----------------|-----------|
| HOW to write code | `E:\Unity\Sandbox\Documents\Canonical\TecVooDoo_CodingStandards.md` | Before recommending a code pattern, library, or refactor. Check Revision History header. |
| HOW to work in a session | `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md` | Session-open and session-close. Also: refactor philosophy, MCP/Unity gotchas, user preferences, rule classification. |
| MCP plugin state | `E:\Unity\Sandbox\Documents\Canonical\MCP_ConnectionBrief.md` | Before any MCP version bump, when MCP tools fail unexpectedly, or when `Assets/Plugins/NuGet/` looks wrong. |
| Doc-system spec | `E:\Unity\Sandbox\Documents\Canonical\PerProject_DocSystem.md` | When updating this CLAUDE.md, the doc set shape, or the per-project memory layout. |

---

## Per-project memory

Auto-loaded `MEMORY.md` index lives at `C:\Users\steph\.claude\projects\e--Unity-HideNReap\memory\MEMORY.md`. Contains user role, project concept, repo paths, recovery context, doc map, canonical pointers, and feedback entries (e.g. push-to-main is pre-authorized). Update on session close when a lesson should outlive the conversation.

---

**End of Index**
