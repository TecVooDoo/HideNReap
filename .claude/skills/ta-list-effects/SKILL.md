---
name: ta-list-effects
description: |-
  Lists all available Text Animator effects (behavior and appearance animations).
  Discovers effects via the [EffectInfo] attribute across all loaded assemblies.
  Shows tag ID, category (Behavior/Appearance), and class name.
  Use these tag IDs in rich text tags like <wave>, <shake>, etc.
---

# Text Animator / List Effects

## How to Call

```bash
unity-mcp-cli run-tool ta-list-effects --input '{
  "filter": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ta-list-effects --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ta-list-effects --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `filter` | `string` | No | Optional filter: 'behaviors', 'appearances', or a tag name to search. Leave empty for all. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "filter": {
      "type": "string"
    }
  }
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

