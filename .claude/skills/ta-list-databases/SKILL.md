---
name: ta-list-databases
description: |-
  Lists all AnimationsDatabase assets in the project.
  These databases contain registered Text Animator effects.
  Does not require play mode.
---

# Text Animator / List Databases

## How to Call

```bash
unity-mcp-cli run-tool ta-list-databases --input '{}'
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

