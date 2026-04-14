---
name: rig-configure-twoboneik
description: |-
  Configures a TwoBoneIKConstraint component.
  Requires a TwoBoneIKConstraint already on the named object (add via GameObject menu or gameobject-component-add first).
  rootBoneName / midBoneName / tipBoneName: the three bones in the IK chain (e.g. UpperArm, Forearm, Hand).
  targetName: the IK target transform the tip bone tries to reach.
  hintName: optional pole vector hint for elbow/knee direction.
  targetPositionWeight [0-1]: how strongly the IK drives toward targetName position.
  targetRotationWeight [0-1]: how strongly the IK drives toward targetName rotation.
  hintWeight [0-1]: how strongly the pole vector hint influences the mid-joint direction.
---

# Animation Rigging / Configure Two Bone IK

## How to Call

```bash
unity-mcp-cli run-tool rig-configure-twoboneik --input '{
  "gameObjectName": "string_value",
  "rootBoneName": "string_value",
  "midBoneName": "string_value",
  "tipBoneName": "string_value",
  "targetName": "string_value",
  "hintName": "string_value",
  "targetPositionWeight": "string_value",
  "targetRotationWeight": "string_value",
  "hintWeight": "string_value",
  "weight": "string_value",
  "maintainPositionOffset": "string_value",
  "maintainRotationOffset": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rig-configure-twoboneik --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rig-configure-twoboneik --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with TwoBoneIKConstraint. |
| `rootBoneName` | `string` | No | Name of the root bone (uppermost in the chain, e.g. UpperArm). |
| `midBoneName` | `string` | No | Name of the mid bone (e.g. Forearm or LowerLeg). |
| `tipBoneName` | `string` | No | Name of the tip bone (e.g. Hand or Foot). |
| `targetName` | `string` | No | Name of the IK target GameObject. |
| `hintName` | `string` | No | Name of the IK hint (pole vector) GameObject. Optional. |
| `targetPositionWeight` | `any` | No | Position weight [0-1]. 1 = tip fully reaches target position. |
| `targetRotationWeight` | `any` | No | Rotation weight [0-1]. 1 = tip fully matches target rotation. |
| `hintWeight` | `any` | No | Hint (pole vector) weight [0-1]. |
| `weight` | `any` | No | Constraint blend weight [0-1]. |
| `maintainPositionOffset` | `any` | No | Maintain current offset between target and tip on enable. |
| `maintainRotationOffset` | `any` | No | Maintain current rotation offset between target and tip on enable. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "rootBoneName": {
      "type": "string"
    },
    "midBoneName": {
      "type": "string"
    },
    "tipBoneName": {
      "type": "string"
    },
    "targetName": {
      "type": "string"
    },
    "hintName": {
      "type": "string"
    },
    "targetPositionWeight": {
      "$ref": "#/$defs/System.Single"
    },
    "targetRotationWeight": {
      "$ref": "#/$defs/System.Single"
    },
    "hintWeight": {
      "$ref": "#/$defs/System.Single"
    },
    "weight": {
      "$ref": "#/$defs/System.Single"
    },
    "maintainPositionOffset": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maintainRotationOffset": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
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

