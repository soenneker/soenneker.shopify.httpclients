using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Shopify.HttpClients.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for Shopify's GraphQL API.
/// </summary>
public interface IShopifyGraphQlHttpClient: IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
