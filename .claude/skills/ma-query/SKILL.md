---
name: ma-query
description: |-
  Lists all sound groups, buses, playlists, master volume, mute state, and currently playing variations.
  Use this to inspect the full Master Audio runtime state before making changes.
---

# Master Audio / Query

## How to Call

```bash
unity-mcp-cli run-tool ma-query --input '{}'
```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

This tool takes no input parameters.

### Input JSON Schema

```json
{
  "type": "object",
  "additionalProperties": false
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

