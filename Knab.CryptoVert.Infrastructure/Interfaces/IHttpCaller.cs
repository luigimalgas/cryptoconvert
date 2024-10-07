using Knab.CryptoVert.Domain.Entities;

namespace Knab.CryptoVert.Infrastructure.Interfaces;

public interface IHttpCaller
{
    public Task Get();
    public Task<List<QuoteResponse>> Post(QuoteRequest request);
    
}