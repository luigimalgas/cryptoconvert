using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knab.CryptoVert.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class QuoteController(ILogger<QuoteController> logger)
{
    private readonly ILogger<QuoteController> _logger = logger;
}