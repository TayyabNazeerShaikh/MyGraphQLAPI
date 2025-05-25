// src/MyGraphQLAPI.API/ErrorHandling/CustomErrorFilter.cs

using HotChocolate;

namespace MyGraphQLAPI.API.ErrorHandling
{
    // Custom error filter to handle exceptions and log them
    public class CustomErrorFilter : IErrorFilter
    {
        private readonly ILogger<CustomErrorFilter> _logger;

        public CustomErrorFilter(ILogger<CustomErrorFilter> logger)
        {
            _logger = logger;
        }

        public IError OnError(IError error)
        {
            // Log the original exception if available
            if (error.Exception != null)
            {
                _logger.LogError(error.Exception, "GraphQL Error: {ErrorMessage}", error.Message);
            }
            else
            {
                _logger.LogError("GraphQL Error: {ErrorMessage}", error.Message);
            }

            // You can modify the error object returned to the client here.
            // For production, you might want to hide exception details unless
            // Hot Chocolate's ModifyRequestOptions is configured to show them
            // based on environment (as done in Program.cs).

            // Example: Add custom error code or extension
            // return error.WithCode("CUSTOM_ERROR_CODE").WithExtensions(new Dictionary<string, object?> { { "myCustomField", "some value" } });

            // Return the error object (either original or modified)
            return error;
        }
    }
}