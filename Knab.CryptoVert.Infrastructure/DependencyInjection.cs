using Knab.CryptoVert.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Knab.CryptoVert.Infrastructure;

public static class DependencyInjection
{
    // Inject Configuration
    private static IConfiguration Configuration { get; set; }
    
    public static IServiceCollection AddApiSettings(this IServiceCollection services)
    {
        services.AddOptions<ApiSettings>("ExchangeApi");

        return services;
    }
}