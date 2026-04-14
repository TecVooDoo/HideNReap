---
name: aline-label
description: |-
  Draws a 2D text label at a world position in the Scene View using ALINE.
  Persists for 'duration' seconds. Useful for annotating objects, coordinates, or debug info.
  Can position at a named GameObject's world position.
---

# ALINE / Draw Label

## How to Call

```bash
unity-mcp-cli run-tool aline-label --input '{
  "text": "string_value",
  "x": 0,
  "y": 0,
  "z": 0,
  "objectName": "string_value",
  "fontSize": 0,
  "duration": 0,
  "colorR": 0,
  "colorG": 0,
  "colorB": 0,
  "colorA": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool aline-label --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool aline-label --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `text` | `string` | Yes | Label text to display. |
| `x` | `number` | No | Position X (world space). |
| `y` | `number` | No | Position Y (world space). |
| `z` | `number` | No | Position Z (world space). |
| `objectName` | `string` | No | Name of a GameObject to use as position (overrides x/y/z). |
| `fontSize` | `number` | No | Font size in pixels (default 14). |
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
    "text": {
      "type": "string"
    },
    "x": {
      "type": "number"
    },
    "y": {
      "type": "number"
    },
    "z": {
      "type": "number"
    },
    "objectName": {
      "type": "string"
    },
    "fontSize": {
      "type": "number"
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
  },
  "required": [
    "text"
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

