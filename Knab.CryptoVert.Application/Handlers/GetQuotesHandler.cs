using System.Text.Json;
using Knab.CryptoVert.Application.Query;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using MediatR;

namespace Knab.CryptoVert.Application.Handlers;

public class GetQuotesHandler(IHttpCaller httpCaller) 
    : IRequestHandler<GetQuoteQuery, List<QuoteResponse>>
{
    // Handles the GetQuoteQuery and returns a list of QuoteResponse objects.
    public async Task<List<QuoteResponse>> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        // Create a quote request using the currency from the request.
        var quoteRequest = new QuoteRequest
        {
            Currency = request.Currency
        };

        // Send the quote request and get the response.
        var response = await httpCaller.GetQuote(quoteRequest);

        // Map the HTTP response to a list of QuoteResponse objects and return it.
        return MapQuoteResponse(response);
    }

    private List<QuoteResponse> MapQuoteResponse(HttpResponseMessage responseMessage)
    {
        var quoteResponses = new List<QuoteResponse>();
        if (responseMessage.IsSuccessStatusCode)
        {
            quoteResponses = JsonSerializer.Deserialize<List<QuoteResponse>>(
                responseMessage.Content.ReadAsStringAsync().Result);
        }
        
        return quoteResponses ?? [];
    }
}