using Knab.CryptoVert.Application.Interface;
using Knab.CryptoVert.Domain.Entities;
using Newtonsoft.Json;

namespace Knab.CryptoVert.Application.Mappers;

public class QuoteResponseMapper : IQuoteResponseMapper
{
    public async Task<QuoteResponse?> Map(HttpResponseMessage? responseMessage)
    {
        var quoteResponses = new QuoteResponse();
        if (responseMessage == null) return quoteResponses;
        
        var content = await responseMessage.Content.ReadAsStringAsync();
        quoteResponses = JsonConvert.DeserializeObject<QuoteResponse>(content);

        return quoteResponses;
    }
}