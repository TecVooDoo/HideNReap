---
name: flexalon-create-flexible-layout
description: |-
  Creates a new GameObject with a Flexalon Flexible Layout component.
  This is a linear layout (like CSS flexbox). Children are placed one after another along a direction.
  Supports wrapping. Use 'flexalon-add-child' to populate it with objects.
---

# Flexalon / Create Flexible Layout

## How to Call

```bash
unity-mcp-cli run-tool flexalon-create-flexible-layout --input '{
  "name": "string_value",
  "direction": "string_value",
  "gap": 0,
  "wrap": false,
  "wrapDirection": "string_value",
  "wrapGap": 0,
  "horizontalAlign": "string_value",
  "verticalAlign": "string_value",
  "position": "string_value",
  "parentGameObjectRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-create-flexible-layout --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-create-flexible-layout --input-file - <<'EOF'
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
| `direction` | `string` | No | Direction to lay out children: 'PositiveX' (right), 'NegativeX' (left), 'PositiveY' (up), 'NegativeY' (down), 'PositiveZ' (forward), 'NegativeZ' (back). Default 'PositiveX'. |
| `gap` | `number` | No | Gap between children. Default 0.1. |
| `wrap` | `boolean` | No | Enable wrapping to next line when out of space. Default false. |
| `wrapDirection` | `string` | No | Direction to wrap: 'NegativeY' (default), 'PositiveY', 'PositiveZ', etc. |
| `wrapGap` | `number` | No | Gap between wrap lines. Default 0.1. |
| `horizontalAlign` | `string` | No | Horizontal alignment: 'Start', 'Center', 'End'. Default 'Center'. |
| `verticalAlign` | `string` | No | Vertical alignment: 'Start', 'Center', 'End'. Default 'Center'. |
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
    "direction": {
      "type": "string"
    },
    "gap": {
      "type": "number"
    },
    "wrap": {
      "type": "boolean"
    },
    "wrapDirection": {
      "type": "string"
    },
    "wrapGap": {
      "type": "number"
    },
    "horizontalAlign": {
      "type": "string"
    },
    "verticalAlign": {
      "type": "string"
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+FlexibleLayoutResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+FlexibleLayoutResponse": {
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
        "direction": {
          "type": "string",
          "description": "Direction children are laid out"
        },
        "gap": {
          "type": "number",
          "description": "Gap between children"
        },
        "wrap": {
          "type": "boolean",
          "description": "Whether wrapping is enabled"
        },
        "position": {
          "type": "string",
          "description": "World position"
        }
      },
      "required": [
        "instanceId",
        "gap",
        "wrap"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

