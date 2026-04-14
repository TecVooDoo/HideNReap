---
name: nav-configure-link
description: |-
  Configures a NavMeshLink component. All parameters optional.
  Sets up navigable connections between NavMesh surfaces (e.g. jump points, ladders, teleporters).
  startTransformName/endTransformName: names of GameObjects to track (overrides manual start/end points).
---

# AI Navigation / Configure Link

## How to Call

```bash
unity-mcp-cli run-tool nav-configure-link --input '{
  "gameObjectName": "string_value",
  "agentTypeID": "string_value",
  "startX": "string_value",
  "startY": "string_value",
  "startZ": "string_value",
  "endX": "string_value",
  "endY": "string_value",
  "endZ": "string_value",
  "startTransformName": "string_value",
  "endTransformName": "string_value",
  "width": "string_value",
  "costModifier": "string_value",
  "bidirectional": "string_value",
  "autoUpdate": "string_value",
  "area": "string_value",
  "activated": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool nav-configure-link --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool nav-configure-link --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with NavMeshLink. |
| `agentTypeID` | `any` | No | Agent type ID. |
| `startX` | `any` | No | Start point X (local space). |
| `startY` | `any` | No | Start point Y (local space). |
| `startZ` | `any` | No | Start point Z (local space). |
| `endX` | `any` | No | End point X (local space). |
| `endY` | `any` | No | End point Y (local space). |
| `endZ` | `any` | No | End point Z (local space). |
| `startTransformName` | `string` | No | Name of GameObject to track as start point. |
| `endTransformName` | `string` | No | Name of GameObject to track as end point. |
| `width` | `any` | No | Link width. |
| `costModifier` | `any` | No | Cost modifier (negative = use area cost). |
| `bidirectional` | `any` | No | Allow traversal in both directions. |
| `autoUpdate` | `any` | No | Auto-update when transforms move. |
| `area` | `any` | No | Area type of the link. |
| `activated` | `any` | No | Whether agents can traverse this link. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "agentTypeID": {
      "$ref": "#/$defs/System.Int32"
    },
    "startX": {
      "$ref": "#/$defs/System.Single"
    },
    "startY": {
      "$ref": "#/$defs/System.Single"
    },
    "startZ": {
      "$ref": "#/$defs/System.Single"
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
    "startTransformName": {
      "type": "string"
    },
    "endTransformName": {
      "type": "string"
    },
    "width": {
      "$ref": "#/$defs/System.Single"
    },
    "costModifier": {
      "$ref": "#/$defs/System.Single"
    },
    "bidirectional": {
      "$ref": "#/$defs/System.Boolean"
    },
    "autoUpdate": {
      "$ref": "#/$defs/System.Boolean"
    },
    "area": {
      "$ref": "#/$defs/System.Int32"
    },
    "activated": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    },
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

