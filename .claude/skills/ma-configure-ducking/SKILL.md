---
name: ma-configure-ducking
description: |-
  Configure music ducking for a sound group.
  Add a group to the duck list so music volume ducks when the group plays, or remove it.
  duckedVolCut: volume reduction in dB when ducked (default -6).
  unduckTime: seconds to restore music volume after sound ends (default 1.0).
  riseVolStart: normalized position (0-1) of remaining sound when volume restore begins (default 0.5).
---

# Master Audio / Configure Ducking

## How to Call

```bash
unity-mcp-cli run-tool ma-configure-ducking --input '{
  "groupName": "string_value",
  "action": "string_value",
  "duckedVolCut": "string_value",
  "unduckTime": "string_value",
  "riseVolStart": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ma-configure-ducking --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ma-configure-ducking --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `groupName` | `string` | Yes | Sound group name to add/remove from duck list. |
| `action` | `string` | Yes | Action: add or remove. |
| `duckedVolCut` | `any` | No | Volume cut in dB when ducked. Default -6. |
| `unduckTime` | `any` | No | Time in seconds to restore volume. Default 1.0. |
| `riseVolStart` | `any` | No | Normalized position (0-1) of sound remaining when restore begins. Default 0.5. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "groupName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "duckedVolCut": {
      "$ref": "#/$defs/System.Single"
    },
    "unduckTime": {
      "$ref": "#/$defs/System.Single"
    },
    "riseVolStart": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "groupName",
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

