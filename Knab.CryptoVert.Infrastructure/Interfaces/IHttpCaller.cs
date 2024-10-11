using Knab.CryptoVert.Domain.Entities;

namespace Knab.CryptoVert.Infrastructure.Interfaces;

public interface IHttpCaller
{
    public Task<HttpResponseMessage?> GetQuote(QuoteRequest? request);
    
}