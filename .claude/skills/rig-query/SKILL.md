---
name: rig-query
description: |-
  Lists all Animation Rigging components on a GameObject and its hierarchy.
  Reports: RigBuilder (layers, active state), Rig (weight), and all constraints
  (TwoBoneIKConstraint, MultiAimConstraint, MultiParentConstraint, ChainIKConstraint)
  with their current weights and key configuration.
  Use gameObjectName for the Animator/RigBuilder root, or a specific Rig/constraint object.
---

# Animation Rigging / Query Rig Setup

## How to Call

```bash
unity-mcp-cli run-tool rig-query --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rig-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rig-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to inspect (Animator root, Rig, or constraint). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
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

