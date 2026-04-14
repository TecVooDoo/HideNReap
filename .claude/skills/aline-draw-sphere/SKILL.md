---
name: aline-draw-sphere
description: |-
  Draws a wire sphere in the Scene View using ALINE.
  Persists for 'duration' seconds. Useful for visualizing trigger zones, ranges, or spawn points.
  Can position at a named GameObject's world position.
---

# ALINE / Draw Sphere

## How to Call

```bash
unity-mcp-cli run-tool aline-draw-sphere --input '{
  "x": 0,
  "y": 0,
  "z": 0,
  "radius": 0,
  "centerObjectName": "string_value",
  "duration": 0,
  "colorR": 0,
  "colorG": 0,
  "colorB": 0,
  "colorA": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool aline-draw-sphere --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool aline-draw-sphere --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `x` | `number` | No | Center X position (world space). |
| `y` | `number` | No | Center Y position (world space). |
| `z` | `number` | No | Center Z position (world space). |
| `radius` | `number` | No | Sphere radius. |
| `centerObjectName` | `string` | No | Name of a GameObject to use as center position (overrides x/y/z). |
| `duration` | `number` | No | Duration in seconds (default 10s). |
| `colorR` | `number` | No | Color red [0-1]. |
| `colorG` | `number` | No | Color green [0-1]. |
| `colorB` | `number` | No | Color blue [0-1]. |
| `colorA` | `number` | No | Color alpha [0-1]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "x": {
      "type": "number"
    },
    "y": {
      "type": "number"
    },
    "z": {
      "type": "number"
    },
    "radius": {
      "type": "number"
    },
    "centerObjectName": {
      "type": "string"
    },
    "duration": {
      "type": "number"
    },
    "colorR": {
      "type": "number"
    },
    "colorG": {
      "type": "number"
    },
    "colorB": {
      "type": "number"
    },
    "colorA": {
      "type": "number"
    }
  }
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

