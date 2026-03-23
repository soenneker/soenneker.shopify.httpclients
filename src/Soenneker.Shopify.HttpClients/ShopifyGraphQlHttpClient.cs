using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Shopify.HttpClients;

///<inheritdoc cref="IShopifyGraphQlHttpClient"/>
public sealed class ShopifyGraphQlHttpClient : IShopifyGraphQlHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrlTemplate = "https://{store_name}.myshopify.com/admin/api/{api_version}/graphql.json";
    private const string _defaultApiVersion = "2026-01";

    public ShopifyGraphQlHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(ShopifyGraphQlHttpClient), (config: _config, baseUrl: ResolveBaseUrl(_config)), static state =>
        {
            var apiKey = state.config.GetValueStrict<string>("Shopify:AccessToken");

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.baseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    { "X-Shopify-Access-Token", apiKey },
                }
            };
        }, cancellationToken);
    }

    private static string ResolveBaseUrl(IConfiguration config)
    {
        string? clientBaseUrl = config["Shopify:ClientBaseUrl"];

        if (!string.IsNullOrWhiteSpace(clientBaseUrl))
            return clientBaseUrl;

        string storeName = config.GetValueStrict<string>("Shopify:StoreName");
        string apiVersion = config["Shopify:ApiVersion"] ?? _defaultApiVersion;

        return _prodBaseUrlTemplate
            .Replace("{store_name}", storeName, StringComparison.Ordinal)
            .Replace("{api_version}", apiVersion, StringComparison.Ordinal);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(ShopifyGraphQlHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(ShopifyGraphQlHttpClient));
    }
}