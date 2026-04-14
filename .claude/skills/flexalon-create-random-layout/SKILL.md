---
name: flexalon-create-random-layout
description: |-
  Creates a new GameObject with a Flexalon Random Layout component.
  Children are placed at random positions within the layout bounds.
  Great for scattering objects like trees, rocks, debris, etc.
---

# Flexalon / Create Random Layout

## How to Call

```bash
unity-mcp-cli run-tool flexalon-create-random-layout --input '{
  "name": "string_value",
  "randomSeed": 0,
  "randomizeRotation": false,
  "size": "string_value",
  "position": "string_value",
  "parentGameObjectRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-create-random-layout --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-create-random-layout --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `name` | `string` | No | Name for the layout GameObject. |
| `randomSeed` | `integer` | No | Random seed for reproducible layouts. Default 1. |
| `randomizeRotation` | `boolean` | No | Whether to randomize child rotations. Default false. |
| `size` | `any` | No | Size of the random area (width, height, depth). Default (10, 1, 10). |
| `position` | `any` | No | World position. Default (0,0,0). |
| `parentGameObjectRef` | `any` | No | Parent GameObject reference. Null for scene root. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "randomSeed": {
      "type": "integer"
    },
    "randomizeRotation": {
      "type": "boolean"
    },
    "size": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "position": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "parentGameObjectRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
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
    },
    "System.Type": {
      "type": "string"
    },
    "com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef": {
      "type": "object",
      "properties": {
        "instanceID": {
          "type": "integer",
          "description": "instanceID of the UnityEngine.Object. If it is '0' and 'path', 'name', 'assetPath' and 'assetGuid' is not provided, empty or null, then it will be used as 'null'. Priority: 1 (Recommended)"
        },
        "path": {
          "type": "string",
          "description": "Path of a GameObject in the hierarchy Sample 'character/hand/finger/particle'. Priority: 2."
        },
        "name": {
          "type": "string",
          "description": "Name of a GameObject in hierarchy. Priority: 3."
        },
        "assetType": {
          "$ref": "#/$defs/System.Type",
          "description": "Type of the asset."
        },
        "assetPath": {
          "type": "string",
          "description": "Path to the asset within the project. Starts with 'Assets/'"
        },
        "assetGuid": {
          "type": "string",
          "description": "Unique identifier for the asset."
        }
      },
      "required": [
        "instanceID"
      ],
      "description": "Find GameObject in opened Prefab or in the active Scene."
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+RandomLayoutResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+RandomLayoutResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the created GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID"
        },
        "randomSeed": {
          "type": "integer",
          "description": "Random seed used"
        },
        "position": {
          "type": "string",
          "description": "World position"
        }
      },
      "required": [
        "instanceId",
        "randomSeed"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

