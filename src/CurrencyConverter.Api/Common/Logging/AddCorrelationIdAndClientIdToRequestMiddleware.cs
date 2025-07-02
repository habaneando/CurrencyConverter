using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace CurrencyConverter.Api;

public class AddCorrelationIdAndClientIdToRequestMiddleware
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";

    private const string ClientIdHeaderName = "X-Client-Id";

    private readonly RequestDelegate _next;

    ILogger<AddCorrelationIdAndClientIdToRequestMiddleware> _logger;

    public AddCorrelationIdAndClientIdToRequestMiddleware(
        RequestDelegate next,
        ILogger<AddCorrelationIdAndClientIdToRequestMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        string correlationId = GetCorrelationId(context);

        string clientId = GetClientId(context);

        try
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                return _next.Invoke(context);
            }
        }
        catch (Exception ex)
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                _logger.LogError(ex, "Exception in {Method} {Path}, StatusCode: {StatusCode}, ResponseTime: {ResponseTimeMs:F2}ms");
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsJsonAsync(
                new
                {
                    Error = "An unexpected error occurred",
                    CorrelationId = correlationId
                });
        }
    }

    private  string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier ?? "Unknown";
    }

    private  string GetClientId(HttpContext context)
    {
        var clientId = context.User?.FindFirst(ClientIdHeaderName)?.Value ?? "Unknown";

        return clientId;
    }
}
