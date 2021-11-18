using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;
        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogResponse(context);
            await _next(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.ContentLength > 0)
                {
                    var route = context.Request.RouteValues;
                    var url = context.Request.GetDisplayUrl();
                
                    string headers = string.Empty;
                    foreach (string header in context.Response.Headers.Keys)
                    {
                        string[] values = context.Response.Headers.GetCommaSeparatedValues(header);
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