---
name: ma-play
description: |-
  Play a sound by group name. Supports 2D and 3D positional audio.
  Provide position as 'x,y,z' for 3D spatialized playback.
---

# Master Audio / Play Sound

## How to Call

```bash
unity-mcp-cli run-tool ma-play --input '{
  "groupName": "string_value",
  "volume": "string_value",
  "pitch": "string_value",
  "delay": "string_value",
  "position": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ma-play --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ma-play --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `groupName` | `string` | Yes | Sound group name to play. |
| `volume` | `any` | No | Volume percentage 0-1. Default 1.0. |
| `pitch` | `any` | No | Pitch override. Null uses group default. |
| `delay` | `any` | No | Delay in seconds before playback. Default 0. |
| `position` | `string` | No | World position as 'x,y,z' for 3D sound. Omit for 2D. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "groupName": {
      "type": "string"
    },
    "volume": {
      "$ref": "#/$defs/System.Single"
    },
    "pitch": {
      "$ref": "#/$defs/System.Single"
    },
    "delay": {
      "$ref": "#/$defs/System.Single"
    },
    "position": {
      "type": "string"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "groupName"
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

