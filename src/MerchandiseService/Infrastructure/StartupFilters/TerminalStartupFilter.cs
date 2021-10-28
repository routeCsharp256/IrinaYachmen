using System;
using MerchandiseService.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter: IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map(pathMatch: "/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map(pathMatch: "/live", builder => builder.UseMiddleware<LiveMiddleware>());
                app.Map(pathMatch: "/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.UseMiddleware<ResponseLoggingMiddleware>();
                next(app);
            };
        }
    }
}