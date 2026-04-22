using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Shopify.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ShopifyGraphQlHttpClientTests : HostedUnitTest
{
    private readonly IShopifyGraphQlHttpClient _httpclient;

    public ShopifyGraphQlHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IShopifyGraphQlHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
