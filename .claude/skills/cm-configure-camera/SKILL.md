---
name: cm-configure-camera
description: |-
  Configures a CinemachineCamera component.
  priority: controls which camera is live when multiple cameras are active (higher wins).
  fov: vertical field of view in degrees (default 60).
  nearClip / farClip: camera clipping planes.
  dutch: camera roll offset in degrees.
  trackingTargetName / lookAtTargetName: assign named scene objects as targets.
---

# Cinemachine / Configure Camera

## How to Call

```bash
unity-mcp-cli run-tool cm-configure-camera --input '{
  "gameObjectName": "string_value",
  "priority": "string_value",
  "fov": "string_value",
  "nearClip": "string_value",
  "farClip": "string_value",
  "dutch": "string_value",
  "trackingTargetName": "string_value",
  "lookAtTargetName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool cm-configure-camera --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool cm-configure-camera --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with CinemachineCamera. |
| `priority` | `any` | No | Camera priority -- higher priority cameras take control. |
| `fov` | `any` | No | Vertical field of view in degrees. |
| `nearClip` | `any` | No | Near clip plane distance. |
| `farClip` | `any` | No | Far clip plane distance. |
| `dutch` | `any` | No | Camera dutch (roll) in degrees. |
| `trackingTargetName` | `string` | No | Name of the tracking (follow) target GameObject. |
| `lookAtTargetName` | `string` | No | Name of the look-at target GameObject. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "priority": {
      "$ref": "#/$defs/System.Int32"
    },
    "fov": {
      "$ref": "#/$defs/System.Single"
    },
    "nearClip": {
      "$ref": "#/$defs/System.Single"
    },
    "farClip": {
      "$ref": "#/$defs/System.Single"
    },
    "dutch": {
      "$ref": "#/$defs/System.Single"
    },
    "trackingTargetName": {
      "type": "string"
    },
    "lookAtTargetName": {
      "type": "string"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    },
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

