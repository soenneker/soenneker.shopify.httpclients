using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Shopify.HttpClients.Registrars;

/// <summary>
/// Registers the authenticated Shopify Admin GraphQL HTTP client provider.
/// </summary>
public static class ShopifyGraphQlHttpClientRegistrar
{
    /// <summary>
    /// Adds the Shopify Admin GraphQL HTTP client provider as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IShopifyGraphQlHttpClient, ShopifyGraphQlHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds the Shopify Admin GraphQL HTTP client provider as a scoped service. Each scope owns a separate cached HTTP client. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IShopifyGraphQlHttpClient, ShopifyGraphQlHttpClient>();

        return services;
    }
}
