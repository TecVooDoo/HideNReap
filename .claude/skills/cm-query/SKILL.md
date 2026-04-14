---
name: cm-query
description: |-
  Reads the full setup of a CinemachineCamera or CinemachineBrain.
  For CinemachineCamera: reports Priority, Target, Lens settings (FOV, clip planes, Dutch),
  and all pipeline components (CinemachineFollow, CinemachinePositionComposer,
  CinemachineRotationComposer, CinemachineThirdPersonFollow, CinemachineBasicMultiChannelPerlin).
  For CinemachineBrain: reports DefaultBlend, UpdateMethod, IgnoreTimeScale.
---

# Cinemachine / Query Camera

## How to Call

```bash
unity-mcp-cli run-tool cm-query --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool cm-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool cm-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with CinemachineCamera or CinemachineBrain component. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
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

