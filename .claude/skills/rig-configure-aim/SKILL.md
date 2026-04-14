---
name: rig-configure-aim
description: |-
  Configures a MultiAimConstraint component.
  MultiAimConstraint makes a bone (e.g. Head, Spine) aim toward one or more source transforms.
  constrainedObjectName: the bone/transform to be aimed.
  sourceNames: comma-separated list of source object names (e.g. 'Target1,Target2').
  sourceWeights: comma-separated weights matching sourceNames (e.g. '1.0,0.5').
  If sources already exist, existing entries are preserved and new ones are appended.
---

# Animation Rigging / Configure Multi Aim Constraint

## How to Call

```bash
unity-mcp-cli run-tool rig-configure-aim --input '{
  "gameObjectName": "string_value",
  "constrainedObjectName": "string_value",
  "sourceNames": "string_value",
  "sourceWeights": "string_value",
  "weight": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rig-configure-aim --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rig-configure-aim --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with MultiAimConstraint. |
| `constrainedObjectName` | `string` | No | Name of the bone/transform to be aimed (e.g. Head). |
| `sourceNames` | `string` | No | Comma-separated names of aim source GameObjects. |
| `sourceWeights` | `string` | No | Comma-separated weights for each source [0-1] (must match source count). |
| `weight` | `any` | No | Constraint blend weight [0-1]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "constrainedObjectName": {
      "type": "string"
    },
    "sourceNames": {
      "type": "string"
    },
    "sourceWeights": {
      "type": "string"
    },
    "weight": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
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

