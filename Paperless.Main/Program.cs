using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paperless.Core.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults().ConfigureServices((context, services) =>
    {
        ConfigureServices(context.Configuration, services);
    }).Build();
 
host.Run();


static void ConfigureServices(IConfiguration configuration,
    IServiceCollection services)
{
    services.AddScoped<IExchangeRateService, ExchangeRateService>();
}