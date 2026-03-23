using Soenneker.Shopify.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Shopify.HttpClients.Tests;

[Collection("Collection")]
public sealed class ShopifyGraphQlHttpClientTests : FixturedUnitTest
{
    private readonly IShopifyGraphQlHttpClient _httpclient;

    public ShopifyGraphQlHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IShopifyGraphQlHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
