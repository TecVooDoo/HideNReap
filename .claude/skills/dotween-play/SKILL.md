---
name: dotween-play
description: |-
  Runtime control of DOTweenAnimation components on a GameObject.
  Supports play, pause, rewind, restart, complete, and kill actions.
  Optionally target a specific tween by id.
---

# DOTween / Play Control

## How to Call

```bash
unity-mcp-cli run-tool dotween-play --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "id": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dotween-play --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dotween-play --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with DOTweenAnimation components. |
| `action` | `string` | Yes | Action to perform: play, pause, rewind, restart, complete, kill. |
| `id` | `string` | No | Optional tween id to target a specific animation. Null targets all on the GameObject. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "id": {
      "type": "string"
    }
  },
  "required": [
    "gameObjectName",
    "action"
  ]
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "type": "string"
    }
  },
  "required": [
    "result"
  ]
}
```

