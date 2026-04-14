---
name: cm-configure-noise
description: |-
  Configures a CinemachineBasicMultiChannelPerlin component for camera shake.
  amplitudeGain: overall shake strength (0 = no shake, 1 = default, >1 = stronger).
  frequencyGain: shake speed multiplier (1 = default, higher = faster shaking).
  noiseProfileName: name of a NoiseSettings asset to use as the noise profile.
    Common profiles: 'Handheld_tele_mild', '6D Shake', 'Handheld_normal_mild'.
    Leave null to keep the current profile.
---

# Cinemachine / Configure Noise

## How to Call

```bash
unity-mcp-cli run-tool cm-configure-noise --input '{
  "gameObjectName": "string_value",
  "amplitudeGain": "string_value",
  "frequencyGain": "string_value",
  "noiseProfileName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool cm-configure-noise --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool cm-configure-noise --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with CinemachineBasicMultiChannelPerlin. |
| `amplitudeGain` | `any` | No | Amplitude (shake strength) multiplier. 1=default, 0=no shake. |
| `frequencyGain` | `any` | No | Frequency (shake speed) multiplier. 1=default. |
| `noiseProfileName` | `string` | No | Name of a NoiseSettings asset to load (e.g. 'Handheld_tele_mild'). Searched in all Resources. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "amplitudeGain": {
      "$ref": "#/$defs/System.Single"
    },
    "frequencyGain": {
      "$ref": "#/$defs/System.Single"
    },
    "noiseProfileName": {
      "type": "string"
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

