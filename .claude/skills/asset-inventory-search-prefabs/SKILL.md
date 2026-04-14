---
name: asset-inventory-search-prefabs
description: |-
  Searches specifically for prefab assets by name. Returns asset paths ready for instantiation.
  This is a convenience wrapper that filters to Prefabs type only.
---

# Asset Inventory / Search Prefabs

## How to Call

```bash
unity-mcp-cli run-tool asset-inventory-search-prefabs --input '{
  "searchPhrase": "string_value",
  "packageFilter": "string_value",
  "maxResults": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool asset-inventory-search-prefabs --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool asset-inventory-search-prefabs --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `searchPhrase` | `string` | Yes | Search phrase for prefab names. e.g. 'chair', 'wall', 'tree'. |
| `packageFilter` | `string` | No | Filter results by package name (partial match, case-insensitive). e.g. 'polyperfect', 'synty'. Null for all packages. |
| `maxResults` | `integer` | No | Maximum results. Default 20. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "searchPhrase": {
      "type": "string"
    },
    "packageFilter": {
      "type": "string"
    },
    "maxResults": {
      "type": "integer"
    }
  },
  "required": [
    "searchPhrase"
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
      "$ref": "#/$defs/MCPTools.AssetInventory.Editor.Tool_AssetInventory+SearchResponse"
    }
  },
  "$defs": {
    "MCPTools.AssetInventory.Editor.Tool_AssetInventory+SearchResponse": {
      "type": "object",
      "properties": {
        "resultCount": {
          "type": "integer",
          "description": "Total matching results in database"
        },
        "returnedCount": {
          "type": "integer",
          "description": "Number of results returned"
        },
        "results": {
          "type": "string",
          "description": "Search results with paths and package names"
        }
      },
      "required": [
        "resultCount",
        "returnedCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

