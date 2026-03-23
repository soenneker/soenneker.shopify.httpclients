using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Shopify.HttpClients.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for Shopify's GraphQL API.
/// </summary>
public static class ShopifyGraphQlHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="ShopifyGraphQlHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IShopifyGraphQlHttpClient, ShopifyGraphQlHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ShopifyGraphQlHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddShopifyGraphQlHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IShopifyGraphQlHttpClient, ShopifyGraphQlHttpClient>();

        return services;
    }
}
