---
name: nav-configure-surface
description: |-
  Configures a NavMeshSurface component. All parameters optional — only provided values change.
  collectObjects: All, Volume, Children, MarkedWithModifier.
  useGeometry: RenderMeshes or PhysicsColliders.
  After configuring, call nav-bake to rebuild the NavMesh.
---

# AI Navigation / Configure Surface

## How to Call

```bash
unity-mcp-cli run-tool nav-configure-surface --input '{
  "gameObjectName": "string_value",
  "agentTypeID": "string_value",
  "collectObjects": "string_value",
  "useGeometry": "string_value",
  "layerMask": "string_value",
  "defaultArea": "string_value",
  "ignoreNavMeshAgent": "string_value",
  "ignoreNavMeshObstacle": "string_value",
  "overrideTileSize": "string_value",
  "tileSize": "string_value",
  "overrideVoxelSize": "string_value",
  "voxelSize": "string_value",
  "minRegionArea": "string_value",
  "buildHeightMesh": "string_value",
  "sizeX": "string_value",
  "sizeY": "string_value",
  "sizeZ": "string_value",
  "centerX": "string_value",
  "centerY": "string_value",
  "centerZ": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool nav-configure-surface --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool nav-configure-surface --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with NavMeshSurface. |
| `agentTypeID` | `any` | No | Agent type ID. |
| `collectObjects` | `string` | No | Object collection: All, Volume, Children, MarkedWithModifier. |
| `useGeometry` | `string` | No | Geometry source: RenderMeshes or PhysicsColliders. |
| `layerMask` | `any` | No | Layer mask value for filtering. |
| `defaultArea` | `any` | No | Default area type for unmapped objects. |
| `ignoreNavMeshAgent` | `any` | No | Ignore GameObjects with NavMeshAgent. |
| `ignoreNavMeshObstacle` | `any` | No | Ignore GameObjects with NavMeshObstacle. |
| `overrideTileSize` | `any` | No | Override tile size. |
| `tileSize` | `any` | No | Tile size in voxels [16-1024]. |
| `overrideVoxelSize` | `any` | No | Override voxel size. |
| `voxelSize` | `any` | No | Voxel size in world units. |
| `minRegionArea` | `any` | No | Minimum region area threshold. |
| `buildHeightMesh` | `any` | No | Generate height mesh. |
| `sizeX` | `any` | No | Volume size X. |
| `sizeY` | `any` | No | Volume size Y. |
| `sizeZ` | `any` | No | Volume size Z. |
| `centerX` | `any` | No | Volume center X. |
| `centerY` | `any` | No | Volume center Y. |
| `centerZ` | `any` | No | Volume center Z. |

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
    "collectObjects": {
      "type": "string"
    },
    "useGeometry": {
      "type": "string"
    },
    "layerMask": {
      "$ref": "#/$defs/System.Int32"
    },
    "defaultArea": {
      "$ref": "#/$defs/System.Int32"
    },
    "ignoreNavMeshAgent": {
      "$ref": "#/$defs/System.Boolean"
    },
    "ignoreNavMeshObstacle": {
      "$ref": "#/$defs/System.Boolean"
    },
    "overrideTileSize": {
      "$ref": "#/$defs/System.Boolean"
    },
    "tileSize": {
      "$ref": "#/$defs/System.Int32"
    },
    "overrideVoxelSize": {
      "$ref": "#/$defs/System.Boolean"
    },
    "voxelSize": {
      "$ref": "#/$defs/System.Single"
    },
    "minRegionArea": {
      "$ref": "#/$defs/System.Single"
    },
    "buildHeightMesh": {
      "$ref": "#/$defs/System.Boolean"
    },
    "sizeX": {
      "$ref": "#/$defs/System.Single"
    },
    "sizeY": {
      "$ref": "#/$defs/System.Single"
    },
    "sizeZ": {
      "$ref": "#/$defs/System.Single"
    },
    "centerX": {
      "$ref": "#/$defs/System.Single"
    },
    "centerY": {
      "$ref": "#/$defs/System.Single"
    },
    "centerZ": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    },
    "System.Boolean": {
      "type": "boolean"
    },
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

