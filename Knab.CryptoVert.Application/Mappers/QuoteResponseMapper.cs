using System.Text.Json;
using Knab.CryptoVert.Domain.Entities;
using Newtonsoft.Json;

namespace Knab.CryptoVert.Application.Mappers;

public static class QuoteResponseMapper
{
    public static QuoteResponse? Map(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            PropertyNameCaseInsensitive = true
        };
        var content = responseMessage.Content.ReadAsStringAsync().Result;
        var quoteResponses = JsonConvert.DeserializeObject<QuoteResponse>(content);
        
        return quoteResponses;
    }
}