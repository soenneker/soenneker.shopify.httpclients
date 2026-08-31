[![](https://img.shields.io/nuget/v/soenneker.shopify.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shopify.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.shopify.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.shopify.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shopify.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shopify.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.shopify.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Shopify.HttpClients

Provides a reusable `HttpClient` configured for a store's Shopify Admin GraphQL endpoint and access-token authentication.

## Installation

```bash
dotnet add package Soenneker.Shopify.HttpClients
```

## Configuration

```json
{
  "Shopify": {
    "AccessToken": "your-access-token",
    "StoreName": "your-store",
    "ApiVersion": "2026-07"
  }
}
```

This resolves to `https://your-store.myshopify.com/admin/api/2026-07/graphql.json`.

If you need full control over the endpoint, set `Shopify:ClientBaseUrl` instead:

```json
{
  "Shopify": {
    "AccessToken": "your-access-token",
    "ClientBaseUrl": "https://your-store.myshopify.com/admin/api/2026-07/graphql.json"
  }
}
```

## Usage

```csharp
using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Shopify.HttpClients.Registrars;

services.AddShopifyGraphQlHttpClientAsSingleton();

public sealed class ShopifyGraphQlSender
{
    private readonly IShopifyGraphQlHttpClient _shopify;

    public ShopifyGraphQlSender(IShopifyGraphQlHttpClient shopify)
    {
        _shopify = shopify;
    }

    public async Task<HttpResponseMessage> Send(
        HttpContent graphQlRequest,
        CancellationToken cancellationToken)
    {
        HttpClient client = await _shopify.Get(cancellationToken);
        return await client.PostAsync("", graphQlRequest, cancellationToken);
    }
}
```

The provider owns the cached `HttpClient`; disposing the provider removes and disposes that client. Scoped registration creates an independently owned client for each scope.
