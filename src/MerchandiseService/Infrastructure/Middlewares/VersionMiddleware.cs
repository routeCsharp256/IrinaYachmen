using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
                
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "no name";
            await context.Response.WriteAsync($"version:{version}, serviceName:{serviceName}");
        }
    }
}