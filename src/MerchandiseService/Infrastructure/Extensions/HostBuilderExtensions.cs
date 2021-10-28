using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc(name: "v1", new OpenApiInfo {Title = "MerchandiseService", Version = "v1"});
                });
            });
            
            return builder;
        }
        
        public static IHostBuilder AddHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            });
            
            return builder;
        }
    }
}