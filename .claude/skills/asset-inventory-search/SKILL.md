---
name: asset-inventory-search
description: |-
  Searches the Asset Inventory database for assets by name, type, or tag.
  Returns matching files with their asset paths, package names, and metadata.
  Use this to find prefabs, textures, models, or any indexed asset across all installed packages.
  The search uses the Asset Inventory 4 indexed database for fast results.
---

# Asset Inventory / Search Assets

## How to Call

```bash
unity-mcp-cli run-tool asset-inventory-search --input '{
  "searchPhrase": "string_value",
  "fileType": "string_value",
  "packageFilter": "string_value",
  "maxResults": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool asset-inventory-search --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool asset-inventory-search --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `searchPhrase` | `string` | Yes | Search phrase (name, partial match). e.g. 'chair', 'SM_Bld', 'tree'. |
| `fileType` | `string` | No | Filter by file type: 'Prefabs', 'Models', 'Images', 'Materials', 'Audio', 'Scripts', etc. Null for all types. |
| `packageFilter` | `string` | No | Filter results by package name (partial match, case-insensitive). e.g. 'polyperfect', 'synty'. Null for all packages. |
| `maxResults` | `integer` | No | Maximum number of results to return. Default 20. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "searchPhrase": {
      "type": "string"
    },
    "fileType": {
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

