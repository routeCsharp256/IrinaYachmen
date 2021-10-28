using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    var route = context.Request.RouteValues;
                    var url = context.Request.GetDisplayUrl();
                
                    string headers = string.Empty;
                    foreach (string header in context.Request.Headers.Keys)
                    {
                        string[] values = context.Request.Headers.GetCommaSeparatedValues(header);
                        headers += string.Format("{0}: {1}", header, string.Join(",", values));
                    }
                    _logger.LogInformation(headers);
                    _logger.LogInformation(url);
                    _logger.LogInformation(route.ToString());

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, message:"Could not log request body");
            }
        }
    }
}