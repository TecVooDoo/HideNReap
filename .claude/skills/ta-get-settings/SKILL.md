---
name: ta-get-settings
description: |-
  Lists all AnimatorSettings ScriptableObject assets in the project.
  These control default behavior for Text Animator components (time scale, dynamic scaling, etc.).
  Does not require play mode.
---

# Text Animator / Get Settings

## How to Call

```bash
unity-mcp-cli run-tool ta-get-settings --input '{}'
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

