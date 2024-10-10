# Technical questions

1. How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add
    - I spent about 2 - 3 hours a day over a week but not every evening (~16)
    - I would add the following:
      - Addition unit tests for more coverage. I had include the two major classes into the unit tests but the coeverage is still extremely low
      - I would parameterize the currencies I converted to instead of hardcoding it
      - I would add the rate limiting configuration values to the appsettings file
      - I would implement Azure AD or a more complex method of authorization with more exact roles (this could take time to test and setup)
      - I would refactor the code comply more closely to SOLID principles, though it is quite robust right now it can be tweaked
      - A caching mechanism would also be beneficial in this case since the data does not update too often and if repeat calls are made within lets say a minute it can pull from there
      - Add a retry policy with exponential backoff

2. What was the most useful feature that was added to the latest version of your language of choice?
   - nullability and more concise shorthand statements (e.g. if statements)
   - Seperating dependecy injections from the StartUp.cs file
   - IOptions for seperation of configuration usage in cross projects
    ```c#
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
                
            services.AddScoped<IHttpCaller, HttpCaller>();
            return services;
        }
    }
    ```

3. How would you track down a performance issue in production? Have you ever had to do this?
   - Yes I have done this mainly using Azure monitoring tools and application health
   - Another way would be through the App Service advanced tools. Throuhg this you can access the command line and prompt differenct calls like top to see long running or high usage processes
   - Through Application Insights you can also get a view of failing queries and the resons they would be failing and this can allow you to pinpoint problems and view in depth data on the cause of failures. 
   - Health monitoring gives you an overview of the overall healthy of an App service and this can identify hardware limitations or high load times, In this way you can increase the capacity by scaling the resource to fit the need of the application.

4.  