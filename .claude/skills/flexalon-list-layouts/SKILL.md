---
name: flexalon-list-layouts
description: Lists all Flexalon layout components currently in the scene, with their type and child count.
---

# Flexalon / List Layouts in Scene

## How to Call

```bash
unity-mcp-cli run-tool flexalon-list-layouts --input '{}'
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
      "$ref": "#/$defs/MCPTools.Flexalon.Editor.Tool_Flexalon+ListLayoutsResponse"
    }
  },
  "$defs": {
    "MCPTools.Flexalon.Editor.Tool_Flexalon+ListLayoutsResponse": {
      "type": "object",
      "properties": {
        "count": {
          "type": "integer",
          "description": "Number of layouts found"
        },
        "layouts": {
          "type": "string",
          "description": "List of layouts with details"
        }
      },
      "required": [
        "count"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

