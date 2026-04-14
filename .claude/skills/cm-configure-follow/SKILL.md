---
name: cm-configure-follow
description: |-
  Configures a CinemachineFollow or CinemachineThirdPersonFollow component.
  CinemachineFollow: offset-based follow with damping (good for side-scrollers, top-down, overhead).
    followOffsetX/Y/Z: world offset from target.
    positionDampingX/Y/Z: position damping per axis.
    rotationDampingX/Y/Z: rotation damping per axis.
    bindingMode: WorldSpace, LockToTarget, LockToTargetNoRoll, LazyFollow, etc.
  CinemachineThirdPersonFollow: shoulder rig follow (good for over-the-shoulder TPS).
    shoulderOffsetX/Y/Z: shoulder position relative to target.
    cameraSide: [0-1] where 0=left shoulder, 1=right shoulder.
    cameraDistance: distance behind the shoulder.
---

# Cinemachine / Configure Follow

## How to Call

```bash
unity-mcp-cli run-tool cm-configure-follow --input '{
  "gameObjectName": "string_value",
  "followOffsetX": "string_value",
  "followOffsetY": "string_value",
  "followOffsetZ": "string_value",
  "positionDampingX": "string_value",
  "positionDampingY": "string_value",
  "positionDampingZ": "string_value",
  "rotationDampingX": "string_value",
  "rotationDampingY": "string_value",
  "rotationDampingZ": "string_value",
  "bindingMode": "string_value",
  "shoulderOffsetX": "string_value",
  "shoulderOffsetY": "string_value",
  "shoulderOffsetZ": "string_value",
  "cameraSide": "string_value",
  "cameraDistance": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool cm-configure-follow --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool cm-configure-follow --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with the follow component. |
| `followOffsetX` | `any` | No | Follow offset X (CinemachineFollow only). |
| `followOffsetY` | `any` | No | Follow offset Y (CinemachineFollow only). |
| `followOffsetZ` | `any` | No | Follow offset Z (CinemachineFollow only). |
| `positionDampingX` | `any` | No | Position damping X axis (CinemachineFollow only). |
| `positionDampingY` | `any` | No | Position damping Y axis (CinemachineFollow only). |
| `positionDampingZ` | `any` | No | Position damping Z axis (CinemachineFollow only). |
| `rotationDampingX` | `any` | No | Rotation damping X axis (CinemachineFollow only). |
| `rotationDampingY` | `any` | No | Rotation damping Y axis (CinemachineFollow only). |
| `rotationDampingZ` | `any` | No | Rotation damping Z axis (CinemachineFollow only). |
| `bindingMode` | `string` | No | Binding mode: WorldSpace, LockToTarget, LockToTargetNoRoll, LockToTargetOnAssign, LockToTargetWithWorldUp, LazyFollow. |
| `shoulderOffsetX` | `any` | No | Shoulder offset X (ThirdPersonFollow only). |
| `shoulderOffsetY` | `any` | No | Shoulder offset Y (ThirdPersonFollow only). |
| `shoulderOffsetZ` | `any` | No | Shoulder offset Z (ThirdPersonFollow only). |
| `cameraSide` | `any` | No | Camera side [0-1]: 0=left, 1=right (ThirdPersonFollow only). |
| `cameraDistance` | `any` | No | Camera distance from shoulder (ThirdPersonFollow only). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "followOffsetX": {
      "$ref": "#/$defs/System.Single"
    },
    "followOffsetY": {
      "$ref": "#/$defs/System.Single"
    },
    "followOffsetZ": {
      "$ref": "#/$defs/System.Single"
    },
    "positionDampingX": {
      "$ref": "#/$defs/System.Single"
    },
    "positionDampingY": {
      "$ref": "#/$defs/System.Single"
    },
    "positionDampingZ": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationDampingX": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationDampingY": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationDampingZ": {
      "$ref": "#/$defs/System.Single"
    },
    "bindingMode": {
      "type": "string"
    },
    "shoulderOffsetX": {
      "$ref": "#/$defs/System.Single"
    },
    "shoulderOffsetY": {
      "$ref": "#/$defs/System.Single"
    },
    "shoulderOffsetZ": {
      "$ref": "#/$defs/System.Single"
    },
    "cameraSide": {
      "$ref": "#/$defs/System.Single"
    },
    "cameraDistance": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
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

