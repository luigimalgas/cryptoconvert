using System.Net;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Domain.Entities;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Knab.CryptoVert.Infrastructure.UnitTests.Utilities;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;

namespace Knab.CryptoVert.Infrastructure.UnitTests;

[TestClass]
public class HttpCallerTests
{
    private HttpClient _httpClient;
    private IHttpCaller _httpCaller;
    private Fixture _fixture;
    
    [TestInitialize]
    public void Setup()
    {
        //fixture configuration for nsubstitute
        _fixture = new Fixture();
        _fixture.Customize(new AutoNSubstituteCustomization() { ConfigureMembers = true});
        
        var apiSettings = new ApiSettings
        {
            Header = "YourHeader",
            Url = "https://api.example.com/",
            ApiKey = "YourApiKey"
        };
        var iOptions = Options.Create(apiSettings);
        
        var messageHandler = new MockHttpMessageHandler();
        _httpClient = new HttpClient(messageHandler);
        _httpCaller = Substitute.For<HttpCaller>(iOptions, _httpClient);
    }

    //test when no data is parsed to getquote
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task HttpCaller_GetQuoteFailsEmptyRequest()
    {
        //Arrange
        
        //Act 
        var result = await _httpCaller.GetQuote(null);

        //Assert
    }
    
    //test the happy flow
    [TestMethod]
    public async Task HttpCaller_GetQuoteSucceedsWithResponse()
    {
        //Arrange
        var request = _fixture.Create<QuoteRequest>();
        
        //Act 
        var result = await _httpCaller.GetQuote(request);

        //Assert
        Assert.IsNotNull(result);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Content.Should().NotBeNull();
    }
}