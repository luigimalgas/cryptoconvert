using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;

namespace Knab.CryptoVert.Infrastructure;

public class HttpCaller : IHttpCaller
{
    public async Task Get()
    {
        throw new NotImplementedException();
    }

    public async Task<List<QuoteResponse>> Post(QuoteRequest request)
    {
        var response = new List<QuoteResponse>();
        
        return await Task.FromResult(response);
    }
}