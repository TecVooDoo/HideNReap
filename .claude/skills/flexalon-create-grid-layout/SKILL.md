---
name: flexalon-create-grid-layout
description: |-
  Creates a new GameObject with a Flexalon Grid Layout component.
  Children added to this object will be automatically arranged in a grid pattern.
  Use 'flexalon-add-child' to populate the grid with objects.
---

# Flexalon / Create Grid Layout

## How to Call

```bash
unity-mcp-cli run-tool flexalon-create-grid-layout --input '{
  "name": "string_value",
  "columns": 0,
  "rows": 0,
  "layers": 0,
  "columnSize": 0,
  "rowSize": 0,
  "columnSpacing": 0,
  "rowSpacing": 0,
  "position": "string_value",
  "parentGameObjectRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-create-grid-layout --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-create-grid-layout --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `name` | `string` | No | Name for the grid layout GameObject. |
| `columns` | `integer` | No | Number of columns in the grid. Default 3. |
| `rows` | `integer` | No | Number of rows in the grid. Default 3. |
| `layers` | `integer` | No | Number of layers (depth). Default 1. |
| `columnSize` | `number` | No | Fixed cell width. If 0, cells fill available space. Default 1. |
| `rowSize` | `number` | No | Fixed cell height. If 0, cells fill available space. Default 1. |
| `columnSpacing` | `number` | No | Spacing between columns. Default 0.1. |
| `rowSpacing` | `number` | No | Spacing between rows. Default 0.1. |
| `position` | `any` | No | World position for the grid. Default (0,0,0). |
| `parentGameObjectRef` | `any` | No | Parent GameObject reference. Null for scene root. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "columns": {
      "type": "integer"
    },
    "rows": {
      "type": "integer"
    },
    "layers": {
      "type": "integer"
    },
    "columnSize": {
      "type": "number"
    },
    "rowSize": {
      "type": "number"
    },
    "columnSpacing": {
      "type": "number"
    },
    "rowSpacing": {
      "type": "number"
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+GridLayoutResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+GridLayoutResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the created GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID of the created GameObject"
        },
        "columns": {
          "type": "integer",
          "description": "Number of columns"
        },
        "rows": {
          "type": "integer",
          "description": "Number of rows"
        },
        "layers": {
          "type": "integer",
          "description": "Number of layers"
        },
        "position": {
          "type": "string",
          "description": "World position"
        }
      },
      "required": [
        "instanceId",
        "columns",
        "rows",
        "layers"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

