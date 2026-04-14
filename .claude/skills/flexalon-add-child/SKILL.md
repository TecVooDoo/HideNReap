---
name: flexalon-add-child
description: |-
  Adds a child GameObject to an existing Flexalon layout. The child can be:
  - A new primitive (cube, sphere, cylinder, etc.)
  - An existing GameObject (moved into the layout)
  - A prefab instance (instantiated from an asset path)
  The layout will automatically arrange the child.
---

# Flexalon / Add Child to Layout

## How to Call

```bash
unity-mcp-cli run-tool flexalon-add-child --input '{
  "layoutRef": "string_value",
  "childType": "string_value",
  "childName": "string_value",
  "existingChildRef": "string_value",
  "prefabPath": "string_value",
  "scale": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-add-child --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-add-child --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `layoutRef` | `any` | Yes | Reference to the Flexalon layout GameObject to add the child to. |
| `childType` | `string` | No | Type of child to add: 'cube', 'sphere', 'cylinder', 'capsule', 'quad', 'empty', 'existing', or 'prefab'. Default 'cube'. |
| `childName` | `string` | No | Name for the new child. Default auto-generated. |
| `existingChildRef` | `any` | No | When childType is 'existing', reference to the existing GameObject to move into the layout. |
| `prefabPath` | `string` | No | When childType is 'prefab', the asset path to the prefab (e.g. 'Assets/Synty/.../.prefab'). |
| `scale` | `any` | No | Scale of the child. Default (1,1,1). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "layoutRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "childType": {
      "type": "string"
    },
    "childName": {
      "type": "string"
    },
    "existingChildRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "prefabPath": {
      "type": "string"
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
    "layoutRef"
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+AddChildResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+AddChildResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the child GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID of the child"
        },
        "childType": {
          "type": "string",
          "description": "Type of child added"
        },
        "layoutName": {
          "type": "string",
          "description": "Name of the layout it was added to"
        },
        "childCount": {
          "type": "integer",
          "description": "Total number of children in the layout"
        }
      },
      "required": [
        "instanceId",
        "childCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

