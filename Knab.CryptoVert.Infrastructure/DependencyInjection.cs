using Knab.CryptoVert.Domain.Configuration;
using Knab.CryptoVert.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Knab.CryptoVert.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApiSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiSettings>(configuration.GetSection("ExchangeApi"));
        services.AddSingleton<IOptionsMonitor<ApiSettings>, OptionsMonitor<ApiSettings>>();
        
        services.AddHttpClient<IHttpCaller, HttpCaller>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetSection("ExchangeApi:Url").Value);
        });
            //.AddPolicyHandler(GetRetryPolicy())
            //.AddPolicyHandler(GetCircuitBreakerPolicy());
            
        services.AddScoped<IHttpCaller, HttpCaller>();
        return services;
    }
}