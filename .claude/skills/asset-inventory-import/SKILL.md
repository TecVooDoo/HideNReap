---
name: asset-inventory-import
description: |-
  Imports a single asset from any indexed package into the project, even if the package is not installed.
  Asset Inventory extracts the requested file and its dependencies from the cached package.
  Use 'asset-inventory-search-prefabs' first to find the exact asset path.
  Import is queued and runs asynchronously — check the Unity Console for completion.
  Optionally adds the prefab to the scene after import completes.
---

# Asset Inventory / Import Asset

## How to Call

```bash
unity-mcp-cli run-tool asset-inventory-import --input '{
  "assetPath": "string_value",
  "withDependencies": false,
  "addToScene": false,
  "position": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool asset-inventory-import --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool asset-inventory-import --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `assetPath` | `string` | Yes | Exact asset path as returned by search, e.g. 'Assets/polyperfect/Low Poly Animated Animals/Prefabs/Animals/Fox.prefab'. |
| `withDependencies` | `boolean` | No | Import with dependencies (materials, textures, meshes). Default true. |
| `addToScene` | `boolean` | No | Also add the prefab to the scene after import. Default false. |
| `position` | `any` | No | World position if adding to scene. Default (0,0,0). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "assetPath": {
      "type": "string"
    },
    "withDependencies": {
      "type": "boolean"
    },
    "addToScene": {
      "type": "boolean"
    },
    "position": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    }
  },
  "$defs": {
    "UnityEngine.Vector3": {
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
        }
      },
      "required": [
        "x",
        "y",
        "z"
      ],
      "additionalProperties": false
    }
  },
  "required": [
    "assetPath"
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
      "$ref": "#/$defs/MCPTools.AssetInventory.Editor.Tool_AssetInventory+ImportResponse"
    }
  },
  "$defs": {
    "MCPTools.AssetInventory.Editor.Tool_AssetInventory+ImportResponse": {
      "type": "object",
      "properties": {
        "assetPath": {
          "type": "string",
          "description": "Requested asset path"
        },
        "packageName": {
          "type": "string",
          "description": "Source package name"
        },
        "addToScene": {
          "type": "boolean",
          "description": "Whether it will be added to scene"
        },
        "message": {
          "type": "string",
          "description": "Status message"
        }
      },
      "required": [
        "addToScene"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

