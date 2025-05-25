// src/MyGraphQLAPI.API/Middleware/RequestLoggingMiddleware.cs (Optional)
// Basic example of custom request logging middleware
using System.Diagnostics;

namespace MyGraphQLAPI.API.Middleware
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
            var watch = Stopwatch.StartNew();
            try
            {
                await _next(context);
            }
            finally
            {
                watch.Stop();
                _logger.LogInformation(
                    "Request {Method} {Path} finished in {ElapsedMilliseconds}ms with status {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    watch.ElapsedMilliseconds,
                    context.Response.StatusCode);
            }
        }
    }
}