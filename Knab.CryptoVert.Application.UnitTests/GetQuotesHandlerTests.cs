using System.Net;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Knab.CryptoVert.Application.Handlers;
using Knab.CryptoVert.Application.Interface;
using Knab.CryptoVert.Application.Mappers;
using Knab.CryptoVert.Application.Query;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using NSubstitute;

namespace Knab.CryptoVert.Application.UnitTests;

[TestClass]
public class GetQuotesHandlerTests
{
    private Fixture? _fixture;
    private IHttpCaller? _httpCaller;
    
    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
        _fixture.Customize(new AutoNSubstituteCustomization() { ConfigureMembers = true});
        _httpCaller = Substitute.For<IHttpCaller>();
    }

    [TestMethod]
    public async Task GetQuotesHandler_GetQuotesAsync_ShouldReturnQuotes()
    {
        //Arrange
        var mapper = Substitute.For<IQuoteResponseMapper>();
        var query = _fixture?
            .Build<GetQuoteQuery>()
            .Create();
        
        var quoteResponse = _fixture.Create<QuoteResponse>();
        var httpResponse = _fixture?.Build<HttpResponseMessage>()
            .With(x=> x.StatusCode, HttpStatusCode.OK)
            .With(x=> x.Content, new StringContent("{ 'some': 'response' }"))
            .Create();
        
        var handler = new GetQuotesHandler(_httpCaller);
        
        //Act
        _httpCaller?.GetQuote(Arg.Any<QuoteRequest?>()).Returns(Task.FromResult(httpResponse));
        mapper.Map(Arg.Any<HttpResponseMessage?>()).Returns(Task.FromResult(quoteResponse));
        var result = await handler.Handle(query, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType(typeof(QuoteResponse));
    }
}