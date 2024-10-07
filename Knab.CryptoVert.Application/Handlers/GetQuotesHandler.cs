using Knab.CryptoVert.Application.Query;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using MediatR;

namespace Knab.CryptoVert.Application.Handlers;

public class GetQuotesHandler(IHttpCaller httpCaller) 
    : IRequestHandler<GetQuoteQuery, List<QuoteResponse>>
{
    public async Task<List<QuoteResponse>> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        var quoteRequest = new QuoteRequest
        {
            Currency = request.Currency
        };
        return await httpCaller.Post(quoteRequest);
    }
}