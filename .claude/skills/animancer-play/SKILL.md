---
name: animancer-play
description: |-
  Plays an animation on an AnimancerComponent by clip asset name.
  fadeDuration: cross-fade duration in seconds (0 = instant switch).
  layer: which layer to play on (default 0).
  speed: playback speed (1 = normal, -1 = reverse, 0.5 = half speed).
  startTime: normalized start time (0 = beginning, 0.5 = halfway, 1 = end). -1 to not set.
  Requires play mode for runtime playback. In edit mode, sets up the state.
---

# Animancer / Play Animation

## How to Call

```bash
unity-mcp-cli run-tool animancer-play --input '{
  "gameObjectName": "string_value",
  "clipName": "string_value",
  "fadeDuration": 0,
  "layer": 0,
  "speed": "string_value",
  "startTime": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool animancer-play --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool animancer-play --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with AnimancerComponent. |
| `clipName` | `string` | Yes | Name of the AnimationClip asset to play. |
| `fadeDuration` | `number` | No | Cross-fade duration in seconds. 0 = instant. |
| `layer` | `integer` | No | Layer index to play on. |
| `speed` | `any` | No | Playback speed. 1 = normal, -1 = reverse. |
| `startTime` | `number` | No | Normalized start time [0-1]. -1 to not set. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "clipName": {
      "type": "string"
    },
    "fadeDuration": {
      "type": "number"
    },
    "layer": {
      "type": "integer"
    },
    "speed": {
      "$ref": "#/$defs/System.Single"
    },
    "startTime": {
      "type": "number"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "gameObjectName",
    "clipName"
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

