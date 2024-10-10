using Knab.CryptoVert.Application.Query;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Knab.CryptoVert.Application.Mappers;
using MediatR;

namespace Knab.CryptoVert.Application.Handlers;

public class GetQuotesHandler(IHttpCaller httpCaller) 
    : IRequestHandler<GetQuoteQuery, QuoteResponse>
{
    // Handles the GetQuoteQuery and returns a list of QuoteResponse objects.
    public async Task<QuoteResponse> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        // Create a quote request using the currency from the request.
        var quoteRequest = new QuoteRequest
        {
            Symbol = request.Currency
        };

        // Send the quote request and get the response.
        var response = await httpCaller.GetQuote(quoteRequest);
        
        // Map the HTTP response to a list of QuoteResponse objects and return it.
        return response.IsSuccessStatusCode ? QuoteResponseMapper.Map(response) : null;
    }
}