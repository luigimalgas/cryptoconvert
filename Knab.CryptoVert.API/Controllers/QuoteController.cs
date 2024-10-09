using Knab.CryptoVert.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knab.CryptoVert.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuoteController(IMediator mediator, ILogger<QuoteController> logger)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<QuoteController> _logger = logger;
    
    [HttpGet]
    [Route("{code}")]
    public async Task<ActionResult> GetQuote([FromRoute] string code)
    {
        var request = new GetQuoteQuery()
        {
            Currency = code
        };
        return Ok(await _mediator.Send(request));
    }
}