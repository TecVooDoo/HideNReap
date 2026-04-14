---
name: ma-playlist
description: |-
  Control playlist playback: play, stop, next, previous, random, pause, unpause, mute, unmute, fade, or change.
  For change action, provide playlistName.
  For fade action, provide volume and optional fadeTime.
  controllerName is optional -- omit to use the first/default PlaylistController.
---

# Master Audio / Playlist Control

## How to Call

```bash
unity-mcp-cli run-tool ma-playlist --input '{
  "action": "string_value",
  "controllerName": "string_value",
  "playlistName": "string_value",
  "clipName": "string_value",
  "volume": "string_value",
  "fadeTime": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ma-playlist --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ma-playlist --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `action` | `string` | Yes | Action: play, stop, next, previous, random, pause, unpause, mute, unmute, fade, change. |
| `controllerName` | `string` | No | PlaylistController name. Null = first/default controller. |
| `playlistName` | `string` | No | Playlist name for 'change' action. |
| `clipName` | `string` | No | Clip name for targeted playback. |
| `volume` | `any` | No | Target volume for fade action (0-1). |
| `fadeTime` | `any` | No | Fade duration in seconds. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "action": {
      "type": "string"
    },
    "controllerName": {
      "type": "string"
    },
    "playlistName": {
      "type": "string"
    },
    "clipName": {
      "type": "string"
    },
    "volume": {
      "$ref": "#/$defs/System.Single"
    },
    "fadeTime": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
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

