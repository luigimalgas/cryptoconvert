using System.Net;

namespace Knab.CryptoVert.Infrastructure.UnitTests.Utilities;

public class MockHttpMessageHandler : HttpMessageHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("my string, that needs to be returned")
        };
    }
    
}