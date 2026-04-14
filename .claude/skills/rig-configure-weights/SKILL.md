---
name: rig-configure-weights
description: |-
  Sets weight on a Rig or constraint component.
  Use this to blend a whole rig in/out (Rig component) or a single constraint in/out.
  weight [0-1]: 0 = constraint has no effect, 1 = full effect.
  Typical workflow: weight=0 to disable IK during a cutscene, weight=1 to re-enable.
  Also can enable/disable a RigBuilder layer by index.
---

# Animation Rigging / Configure Rig Weights

## How to Call

```bash
unity-mcp-cli run-tool rig-configure-weights --input '{
  "gameObjectName": "string_value",
  "weight": "string_value",
  "rigLayerIndex": 0,
  "rigLayerActive": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rig-configure-weights --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rig-configure-weights --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with Rig or constraint component. |
| `weight` | `any` | No | Weight for Rig or any constraint on this object [0-1]. |
| `rigLayerIndex` | `integer` | No | RigBuilder layer index to enable/disable (-1 to skip). |
| `rigLayerActive` | `any` | No | Enable (true) or disable (false) the specified RigBuilder layer. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "weight": {
      "$ref": "#/$defs/System.Single"
    },
    "rigLayerIndex": {
      "type": "integer"
    },
    "rigLayerActive": {
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
    "gameObjectName"
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

