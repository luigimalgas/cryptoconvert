using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Knab.CryptoVert.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApiSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiSettings>(configuration.GetSection("ExchangeApi"));
        services.AddHttpClient<IHttpCaller, HttpCaller>(client =>
        {
            client.BaseAddress = new Uri(configuration["ExchangeApi:Url"]);
        });
            //.AddPolicyHandler(GetRetryPolicy())
            //.AddPolicyHandler(GetCircuitBreakerPolicy());
        return services;
    }
}