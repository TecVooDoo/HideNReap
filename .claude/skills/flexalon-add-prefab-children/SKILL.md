---
name: flexalon-add-prefab-children
description: |-
  Adds multiple instances of a prefab as children of a Flexalon layout.
  Useful for quickly populating a grid or circle with identical objects.
---

# Flexalon / Add Multiple Prefab Children

## How to Call

```bash
unity-mcp-cli run-tool flexalon-add-prefab-children --input '{
  "layoutRef": "string_value",
  "prefabPath": "string_value",
  "count": 0,
  "scale": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-add-prefab-children --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-add-prefab-children --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `layoutRef` | `any` | Yes | Reference to the Flexalon layout GameObject. |
| `prefabPath` | `string` | Yes | Asset path to the prefab (e.g. 'Assets/Synty/.../SM_Something.prefab'). |
| `count` | `integer` | No | Number of instances to add. Default 1. |
| `scale` | `any` | No | Scale for each instance. Default (1,1,1). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "layoutRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "prefabPath": {
      "type": "string"
    },
    "count": {
      "type": "integer"
    },
    "scale": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    }
  },
  "$defs": {
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
    },
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
    "layoutRef",
    "prefabPath"
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+AddMultipleResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+AddMultipleResponse": {
      "type": "object",
      "properties": {
        "layoutName": {
          "type": "string",
          "description": "Name of the layout"
        },
        "prefabName": {
          "type": "string",
          "description": "Name of the prefab used"
        },
        "addedCount": {
          "type": "integer",
          "description": "Number of instances added"
        },
        "totalChildCount": {
          "type": "integer",
          "description": "Total children in the layout"
        }
      },
      "required": [
        "addedCount",
        "totalChildCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

