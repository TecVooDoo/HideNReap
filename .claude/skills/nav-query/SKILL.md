---
name: nav-query
description: |-
  Lists all NavMeshSurfaces, NavMeshLinks, NavMeshModifiers, and NavMeshModifierVolumes in the scene.
  For each surface: agent type, collect mode, geometry source, layer mask, tile/voxel settings, bake status.
  For each link: start/end points, width, cost, bidirectional, area.
  Also reports NavMeshAgent count if any exist.
---

# AI Navigation / Query

## How to Call

```bash
unity-mcp-cli run-tool nav-query --input '{}'
```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

This tool takes no input parameters.

### Input JSON Schema

```json
{
  "type": "object",
  "additionalProperties": false
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

