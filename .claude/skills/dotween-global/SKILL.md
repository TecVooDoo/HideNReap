---
name: dotween-global
description: |-
  Global DOTween control. Affects ALL active tweens in the scene.
  Actions: killall, pauseall, playall, completeall, rewindall.
---

# DOTween / Global Control

## How to Call

```bash
unity-mcp-cli run-tool dotween-global --input '{
  "action": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dotween-global --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dotween-global --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `action` | `string` | Yes | Global action: killall, pauseall, playall, completeall, rewindall. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "action": {
      "type": "string"
    }
  },
  "required": [
    "action"
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

