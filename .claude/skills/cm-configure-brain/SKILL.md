---
name: cm-configure-brain
description: |-
  Configures the CinemachineBrain on a Camera GameObject.
  defaultBlendStyle: transition style between cameras.
    Cut, EaseInOut, EaseIn, EaseOut, HardIn, HardOut, Linear.
  defaultBlendTime: duration of the default transition in seconds.
  updateMethod: when the brain updates -- SmartUpdate, FixedUpdate, LateUpdate.
  ignoreTimeScale: if true, camera cuts always happen instantly regardless of Time.timeScale.
---

# Cinemachine / Configure Brain

## How to Call

```bash
unity-mcp-cli run-tool cm-configure-brain --input '{
  "gameObjectName": "string_value",
  "defaultBlendStyle": "string_value",
  "defaultBlendTime": "string_value",
  "updateMethod": "string_value",
  "ignoreTimeScale": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool cm-configure-brain --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool cm-configure-brain --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with CinemachineBrain (usually the main Camera). |
| `defaultBlendStyle` | `string` | No | Default blend style: Cut, EaseInOut, EaseIn, EaseOut, HardIn, HardOut, Linear. |
| `defaultBlendTime` | `any` | No | Default blend duration in seconds. |
| `updateMethod` | `string` | No | Update method: SmartUpdate, FixedUpdate, LateUpdate. |
| `ignoreTimeScale` | `any` | No | If true, ignore Time.timeScale for camera updates. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "defaultBlendStyle": {
      "type": "string"
    },
    "defaultBlendTime": {
      "$ref": "#/$defs/System.Single"
    },
    "updateMethod": {
      "type": "string"
    },
    "ignoreTimeScale": {
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

