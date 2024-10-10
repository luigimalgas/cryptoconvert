using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace Knab.CryptoVert.Infrastructure;

public class HttpCaller(IOptionsMonitor<ApiSettings> apiSettings, HttpClient httpClient) 
    : IHttpCaller
{    
    private readonly IOptionsMonitor<ApiSettings> _apiSettings = apiSettings;
    public async Task<HttpResponseMessage> GetQuote(QuoteRequest? request)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var httpMessage = new HttpRequestMessage(HttpMethod.Get,
            BuildQuery(request))
        {
            Headers =
            {
                { _apiSettings.CurrentValue.Header, _apiSettings.CurrentValue.ApiKey },
                { "Accept", "application/json" }
            }
        };
        var httpResponseMessage = await httpClient.SendAsync(httpMessage);
        
        return await Task.FromResult(httpResponseMessage);
    }

    private string BuildQuery(QuoteRequest? request)
    {
        var query = new UriBuilder(new Uri(_apiSettings.CurrentValue.Url))
        {
            Path = "v2/cryptocurrency/quotes/latest", //parameterize this
            Query = $"slug={request.Symbol}&convert=USD,EUR,BRL,GBP,AUD" //parameterize this too
        };
        
        return query.ToString();
    }
}