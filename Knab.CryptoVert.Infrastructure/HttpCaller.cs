using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Knab.CryptoVert.Infrastructure;

public class HttpCaller(IOptions<ApiSettings> options, HttpClient httpClient) 
    : IHttpCaller
{
    public async Task Get()
    {
        throw new NotImplementedException();
    }

    // TODO: Change to a Get method
    //Implement the slug and convert variables/ parameters
    public async Task<HttpResponseMessage> Post(QuoteRequest request)
    {
        
        var httpMessage = new HttpRequestMessage(HttpMethod.Get,
            BuildQuery())
        {
            Headers =
            {
                { options.Value.Header, options.Value.ApiKey },
                { "Accepts", "application/json" }
            }
        };
        var httpResponseMessage = await httpClient.SendAsync(httpMessage);
        
        return await Task.FromResult(httpResponseMessage);
    }

    private string BuildQuery()
    {
        var query = new UriBuilder(new Uri(options.Value.Url))
        {
            Path = "cryptocurrency/quotes/latest",
            Query = "slug=bitcoint&convert=USD,EUR,BRL,GBP,AUD"
        };
        
        return query.ToString();
    }
}