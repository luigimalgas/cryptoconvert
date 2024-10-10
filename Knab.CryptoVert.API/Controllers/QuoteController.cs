using Knab.CryptoVert.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knab.CryptoVert.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuoteController(IMediator mediator, ILogger<QuoteController> logger)
    : ControllerBase
{
    private readonly ILogger<QuoteController> _logger = logger;
    
    [HttpGet]
    [Route("{code}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetQuote([FromRoute] string code)
    {
        var request = new GetQuoteQuery()
        {
            Currency = code
        };

        var result = await mediator.Send(request);
        
        return result != null ? Ok(result) : BadRequest(); //Include more return types and move it one level up
    }
}