using System.Diagnostics;

namespace StudentManagementAPI.Middleware
{
    /// <summary>
    /// Custom middleware to log incoming HTTP requests, execution time, and response status codes.
    /// </summary>
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
            var stopwatch = Stopwatch.StartNew();

            // Log incoming request details
            _logger.LogInformation($"[Request] {context.Request.Method} {context.Request.Path} at {DateTime.Now}");

            // Pass control to the next middleware in the pipeline
            await _next(context);

            stopwatch.Stop();

            // Log outgoing response status and time taken
            _logger.LogInformation($"[Response] Status: {context.Response.StatusCode} | Time Taken: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
