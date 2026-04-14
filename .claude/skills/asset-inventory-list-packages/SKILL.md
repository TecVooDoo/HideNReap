---
name: asset-inventory-list-packages
description: |-
  Lists all indexed packages in the Asset Inventory database.
  Shows package names, asset counts, and status. Useful for understanding what content is available.
---

# Asset Inventory / List Packages

## How to Call

```bash
unity-mcp-cli run-tool asset-inventory-list-packages --input '{
  "nameFilter": "string_value",
  "maxResults": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool asset-inventory-list-packages --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool asset-inventory-list-packages --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `nameFilter` | `string` | No | Filter packages by name (partial match). Null for all. |
| `maxResults` | `integer` | No | Maximum packages to list. Default 50. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "nameFilter": {
      "type": "string"
    },
    "maxResults": {
      "type": "integer"
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
      "$ref": "#/$defs/MCPTools.AssetInventory.Editor.Tool_AssetInventory+ListPackagesResponse"
    }
  },
  "$defs": {
    "MCPTools.AssetInventory.Editor.Tool_AssetInventory+ListPackagesResponse": {
      "type": "object",
      "properties": {
        "packageCount": {
          "type": "integer",
          "description": "Number of packages listed"
        },
        "details": {
          "type": "string",
          "description": "Package details"
        }
      },
      "required": [
        "packageCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

