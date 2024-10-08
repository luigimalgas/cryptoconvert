using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Knab.CryptoVert.Infrastructure;

public class HttpCaller(IOptions<ApiSettings> options, HttpClient httpClient) 
    : IHttpCaller
{
    public async Task<HttpResponseMessage> GetQuote(QuoteRequest? request)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var httpMessage = new HttpRequestMessage(HttpMethod.Get,
            BuildQuery(request))
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

    private string BuildQuery(QuoteRequest? request)
    {
        var query = new UriBuilder(new Uri(options.Value.Url))
        {
            Path = "cryptocurrency/quotes/latest",
            Query = $"slug={request.Currency}&convert=USD,EUR,BRL,GBP,AUD"
        };
        
        return query.ToString();
    }
}