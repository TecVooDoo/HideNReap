---
name: animancer-configure
description: |-
  Modifies a currently registered animation state's properties.
  Find the clip by name, then set speed, weight, time, or normalized time.
  Useful for fine-tuning playback without restarting the animation.
---

# Animancer / Configure State

## How to Call

```bash
unity-mcp-cli run-tool animancer-configure --input '{
  "gameObjectName": "string_value",
  "clipName": "string_value",
  "speed": "string_value",
  "weight": "string_value",
  "time": "string_value",
  "normalizedTime": "string_value",
  "isPlaying": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool animancer-configure --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool animancer-configure --input-file - <<'EOF'
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
| `clipName` | `string` | Yes | Name of the AnimationClip to configure. |
| `speed` | `any` | No | Playback speed. |
| `weight` | `any` | No | Blend weight [0-1]. |
| `time` | `any` | No | Playback time in seconds. |
| `normalizedTime` | `any` | No | Normalized playback time [0-1]. |
| `isPlaying` | `any` | No | Is playing state. |

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
    "speed": {
      "$ref": "#/$defs/System.Single"
    },
    "weight": {
      "$ref": "#/$defs/System.Single"
    },
    "time": {
      "$ref": "#/$defs/System.Single"
    },
    "normalizedTime": {
      "$ref": "#/$defs/System.Single"
    },
    "isPlaying": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
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

