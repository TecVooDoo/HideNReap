---
name: ma-bus-control
description: |-
  Control a bus: mute, unmute, solo, unsolo, pause, unpause, stop, fade, or pitch.
  For fade action, provide volume and optional fadeTime.
  For pitch action, provide pitch value.
---

# Master Audio / Bus Control

## How to Call

```bash
unity-mcp-cli run-tool ma-bus-control --input '{
  "busName": "string_value",
  "action": "string_value",
  "volume": "string_value",
  "fadeTime": "string_value",
  "pitch": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ma-bus-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ma-bus-control --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `busName` | `string` | Yes | Bus name. |
| `action` | `string` | Yes | Action: mute, unmute, solo, unsolo, pause, unpause, stop, fade, pitch. |
| `volume` | `any` | No | Target volume for fade action (0-1). |
| `fadeTime` | `any` | No | Fade duration in seconds. Default 1.0. |
| `pitch` | `any` | No | Pitch value for pitch action. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "busName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "volume": {
      "$ref": "#/$defs/System.Single"
    },
    "fadeTime": {
      "$ref": "#/$defs/System.Single"
    },
    "pitch": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "busName",
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

