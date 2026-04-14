---
name: flexalon-set-object-size
description: |-
  Sets the size of a Flexalon Object component on a GameObject.
  FlexalonObject controls how a layout measures the object's bounds.
  Add this to a layout container to define total layout size, or to a child to override its measured size.
---

# Flexalon / Set Object Size

## How to Call

```bash
unity-mcp-cli run-tool flexalon-set-object-size --input '{
  "targetRef": "string_value",
  "width": "string_value",
  "height": "string_value",
  "depth": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-set-object-size --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-set-object-size --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject. |
| `width` | `any` | No | Width (X size). If null, not changed. |
| `height` | `any` | No | Height (Y size). If null, not changed. |
| `depth` | `any` | No | Depth (Z size). If null, not changed. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "width": {
      "$ref": "#/$defs/System.Single"
    },
    "height": {
      "$ref": "#/$defs/System.Single"
    },
    "depth": {
      "$ref": "#/$defs/System.Single"
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
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "targetRef"
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+SetSizeResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+SetSizeResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID"
        },
        "width": {
          "type": "number",
          "description": "Current width"
        },
        "height": {
          "type": "number",
          "description": "Current height"
        },
        "depth": {
          "type": "number",
          "description": "Current depth"
        }
      },
      "required": [
        "instanceId",
        "width",
        "height",
        "depth"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

