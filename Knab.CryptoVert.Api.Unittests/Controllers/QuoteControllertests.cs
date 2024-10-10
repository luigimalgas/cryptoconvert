using AutoFixture;
using Knab.CryptoVert.API.Controllers;
using Knab.CryptoVert.Application.Handlers;
using Knab.CryptoVert.Application.Query;
using Knab.CryptoVert.Domain.Entities;
using NSubstitute;
using FluentAssertions;
using Knab.CryptoVert.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute.ReturnsExtensions;

namespace Knab.CryptoVert.Api.Unittests.Controllers;

[TestClass]
public class QuoteControllertests
{
    private Fixture _fixture;
    private QuoteController _quoteController;
    private IMediator _mediator;
    private ILogger<QuoteController> _logger;
    
    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
        _mediator = Substitute.For<IMediator>();
        _logger = Substitute.For<ILogger<QuoteController>>();
        _quoteController = new QuoteController(_mediator, _logger);
    }
    
    [TestMethod]
    public async Task GetQuote_WithValidQuery_ShouldSucceed()
    {
        //Arrange
        var quoteQuery = _fixture
            .Build<GetQuoteQuery>()
            .With(x=> x.Currency,"test")
            .Create();
        var quoteResponse = _fixture.Create<QuoteResponse>();
        
        //Act 
        _mediator.Send(Arg.Any<GetQuoteQuery>()).Returns(quoteResponse);
        var result = await _quoteController.GetQuote("btc");
        
        //Assert
        result.Should().NotBeNull();
        result.GetType().Should().Be(typeof(OkObjectResult));
        ((OkObjectResult)result).StatusCode.Should().Be(200);
        ((OkObjectResult)result).Value.Should().BeEquivalentTo(quoteResponse);
    }
    
    [TestMethod]
    public async Task GetQuote_WithInValidQuery_ShouldSucceedWithBadRequest()
    {
        //Arrange
        var quoteResponse = _fixture.Create<QuoteResponse>();
        
        //Act 
        _mediator.Send(Arg.Any<GetQuoteQuery>()).ReturnsNull();
        var result = await _quoteController.GetQuote("btc");
        
        //Assert
        result.Should().NotBeNull();
        result.GetType().Should().Be(typeof(BadRequestResult));
    }
}