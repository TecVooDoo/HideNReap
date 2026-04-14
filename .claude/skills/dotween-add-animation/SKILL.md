---
name: dotween-add-animation
description: |-
  Adds and configures a DOTweenAnimation component on a GameObject.
  Supports Move, Scale, Rotate, Fade, Color, PunchPosition, ShakePosition, and all other animation types.
---

# DOTween / Add Animation

## How to Call

```bash
unity-mcp-cli run-tool dotween-add-animation --input '{
  "gameObjectName": "string_value",
  "animationType": "string_value",
  "duration": "string_value",
  "delay": "string_value",
  "ease": "string_value",
  "loops": "string_value",
  "loopType": "string_value",
  "endX": "string_value",
  "endY": "string_value",
  "endZ": "string_value",
  "endFloat": "string_value",
  "id": "string_value",
  "autoPlay": "string_value",
  "isRelative": "string_value",
  "isFrom": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dotween-add-animation --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dotween-add-animation --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add the animation to. |
| `animationType` | `string` | Yes | Animation type: Move, LocalMove, Rotate, LocalRotate, Scale, Color, Fade, Text, PunchPosition, PunchRotation, PunchScale, ShakePosition, ShakeRotation, ShakeScale, CameraFieldOfView, UIWidthHeight, FillAmount. |
| `duration` | `any` | No | Duration in seconds. Default 1.0. |
| `delay` | `any` | No | Delay in seconds before start. Default 0. |
| `ease` | `string` | No | Ease type name: Linear, InSine, OutSine, InOutSine, InQuad, OutQuad, InOutQuad, InCubic, OutCubic, InOutCubic, InBounce, OutBounce, InOutBounce, InElastic, OutElastic, InOutElastic, InBack, OutBack, InOutBack. Default OutQuad. |
| `loops` | `any` | No | Number of loops. -1 for infinite. Default 1. |
| `loopType` | `string` | No | Loop type: Restart, Yoyo, Incremental. Default Restart. |
| `endX` | `any` | No | End value X component for Vector3-based animations. |
| `endY` | `any` | No | End value Y component for Vector3-based animations. |
| `endZ` | `any` | No | End value Z component for Vector3-based animations. |
| `endFloat` | `any` | No | End value float for Fade, FillAmount, CameraFieldOfView, etc. |
| `id` | `string` | No | Tween identifier string for targeting specific tweens. |
| `autoPlay` | `any` | No | Whether the tween plays automatically on start. Default true. |
| `isRelative` | `any` | No | Whether end values are relative to current values. Default false. |
| `isFrom` | `any` | No | Whether the tween animates FROM the end value to the current value. Default false. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "animationType": {
      "type": "string"
    },
    "duration": {
      "$ref": "#/$defs/System.Single"
    },
    "delay": {
      "$ref": "#/$defs/System.Single"
    },
    "ease": {
      "type": "string"
    },
    "loops": {
      "$ref": "#/$defs/System.Int32"
    },
    "loopType": {
      "type": "string"
    },
    "endX": {
      "$ref": "#/$defs/System.Single"
    },
    "endY": {
      "$ref": "#/$defs/System.Single"
    },
    "endZ": {
      "$ref": "#/$defs/System.Single"
    },
    "endFloat": {
      "$ref": "#/$defs/System.Single"
    },
    "id": {
      "type": "string"
    },
    "autoPlay": {
      "$ref": "#/$defs/System.Boolean"
    },
    "isRelative": {
      "$ref": "#/$defs/System.Boolean"
    },
    "isFrom": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
    },
    "System.Boolean": {
      "type": "boolean"
    }
  },
  "required": [
    "gameObjectName",
    "animationType"
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

