using Knab.CryptoVert.Domain.Entities;
using MediatR;

namespace Knab.CryptoVert.Application.Query;

public class GetQuoteQuery
    : IRequest<List<QuoteResponse>>
{
    public required string Currency { get; set; }
}