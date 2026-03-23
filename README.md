[![](https://img.shields.io/nuget/v/soenneker.shopify.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shopify.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.shopify.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.shopify.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Shopify.HttpClients
### A thread-safe singleton HttpClient for Shopify's GraphQL integration.

## Installation

```
dotnet add package Soenneker.Shopify.HttpClients
```

## Configuration

```json
{
  "Shopify": {
    "AccessToken": "your-access-token",
    "StoreName": "your-store",
    "ApiVersion": "2026-01"
  }
}
```

This resolves to `https://your-store.myshopify.com/admin/api/2026-01/graphql.json`.

If you need full control over the endpoint, set `Shopify:ClientBaseUrl` instead:

```json
{
  "Shopify": {
    "AccessToken": "your-access-token",
    "ClientBaseUrl": "https://your-store.myshopify.com/admin/api/2026-01/graphql.json"
  }
}
```
