---
name: flexalon-create-circle-layout
description: |-
  Creates a new GameObject with a Flexalon Circle Layout component.
  Children added to this object will be arranged in a circle or spiral.
  Use 'flexalon-add-child' to populate the circle with objects.
---

# Flexalon / Create Circle Layout

## How to Call

```bash
unity-mcp-cli run-tool flexalon-create-circle-layout --input '{
  "name": "string_value",
  "radius": 0,
  "plane": "string_value",
  "spacingType": "string_value",
  "spacingDegrees": 0,
  "startAtDegrees": 0,
  "rotate": "string_value",
  "spiral": false,
  "spiralSpacing": 0,
  "position": "string_value",
  "parentGameObjectRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool flexalon-create-circle-layout --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool flexalon-create-circle-layout --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `name` | `string` | No | Name for the circle layout GameObject. |
| `radius` | `number` | No | Radius of the circle. Default 3. |
| `plane` | `string` | No | Plane for the circle: XZ (horizontal, default), XY (vertical), or ZY. |
| `spacingType` | `string` | No | Spacing type: 'Evenly' distributes children equally, 'Fixed' uses spacingDegrees. Default 'Evenly'. |
| `spacingDegrees` | `number` | No | Degrees between children when spacingType is 'Fixed'. Default 30. |
| `startAtDegrees` | `number` | No | Starting angle offset in degrees. Default 0. |
| `rotate` | `string` | No | Child rotation: 'None', 'Out', 'In', 'Forward', 'Backward'. Default 'None'. |
| `spiral` | `boolean` | No | Enable spiral mode (children at increasing heights). Default false. |
| `spiralSpacing` | `number` | No | Vertical spacing between objects in spiral. Default 0.5. |
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
    "radius": {
      "type": "number"
    },
    "plane": {
      "type": "string"
    },
    "spacingType": {
      "type": "string"
    },
    "spacingDegrees": {
      "type": "number"
    },
    "startAtDegrees": {
      "type": "number"
    },
    "rotate": {
      "type": "string"
    },
    "spiral": {
      "type": "boolean"
    },
    "spiralSpacing": {
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+CircleLayoutResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+CircleLayoutResponse": {
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
        "radius": {
          "type": "number",
          "description": "Radius of the circle"
        },
        "plane": {
          "type": "string",
          "description": "Plane the circle is on"
        },
        "position": {
          "type": "string",
          "description": "World position"
        }
      },
      "required": [
        "instanceId",
        "radius"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

