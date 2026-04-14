---
name: ta-find-components
description: |-
  Finds all TextAnimator components in the current scene.
  Shows the GameObject name, component type, animation loop mode, and current text.
  Requires a scene to be open.
---

# Text Animator / Find Components

## How to Call

```bash
unity-mcp-cli run-tool ta-find-components --input '{}'
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

