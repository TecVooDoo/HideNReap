---
name: aline-draw-line
description: |-
  Draws a line in the Scene View using ALINE.
  The line persists for 'duration' seconds, then disappears.
  Useful for visualizing directions, distances, or connections between scene objects.
  Can draw from explicit coordinates or between two named scene GameObjects.
  After calling, move the mouse in the Scene View to trigger a repaint.
---

# ALINE / Draw Line

## How to Call

```bash
unity-mcp-cli run-tool aline-draw-line --input '{
  "fromX": 0,
  "fromY": 0,
  "fromZ": 0,
  "toX": 0,
  "toY": 0,
  "toZ": 0,
  "fromObjectName": "string_value",
  "toObjectName": "string_value",
  "duration": 0,
  "colorR": 0,
  "colorG": 0,
  "colorB": 0,
  "colorA": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool aline-draw-line --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool aline-draw-line --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `fromX` | `number` | No | Start X position (world space). |
| `fromY` | `number` | No | Start Y position (world space). |
| `fromZ` | `number` | No | Start Z position (world space). |
| `toX` | `number` | No | End X position (world space). |
| `toY` | `number` | No | End Y position (world space). |
| `toZ` | `number` | No | End Z position (world space). |
| `fromObjectName` | `string` | No | Name of the start GameObject (overrides fromX/Y/Z if set). |
| `toObjectName` | `string` | No | Name of the end GameObject (overrides toX/Y/Z if set). |
| `duration` | `number` | No | Duration in seconds the line persists (default 10s). |
| `colorR` | `number` | No | Color red [0-1]. |
| `colorG` | `number` | No | Color green [0-1]. |
| `colorB` | `number` | No | Color blue [0-1]. |
| `colorA` | `number` | No | Color alpha [0-1]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "fromX": {
      "type": "number"
    },
    "fromY": {
      "type": "number"
    },
    "fromZ": {
      "type": "number"
    },
    "toX": {
      "type": "number"
    },
    "toY": {
      "type": "number"
    },
    "toZ": {
      "type": "number"
    },
    "fromObjectName": {
      "type": "string"
    },
    "toObjectName": {
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

