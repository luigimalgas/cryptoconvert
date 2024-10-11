using Knab.CryptoVert.Domain.Entities;

namespace Knab.CryptoVert.Application.Interface;

public interface IQuoteResponseMapper
{
    Task<QuoteResponse?> Map(HttpResponseMessage? responseMessage);
}