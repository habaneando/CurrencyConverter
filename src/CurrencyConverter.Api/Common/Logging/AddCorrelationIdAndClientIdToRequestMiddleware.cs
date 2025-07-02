using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace CurrencyConverter.Api;

public class AddCorrelationIdAndClientIdToRequestMiddleware(
    RequestDelegate Next,
    ILogger<AddCorrelationIdAndClientIdToRequestMiddleware> Logger,
    ILogFormatter LogFormatter,
    IExceptionFormatter ExceptionFormatter,
    IProblemDetailsFactory ProblemDetailsFactory)
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";

    private const string ClientIdHeaderName = "X-Client-Id";

    public Task Invoke(HttpContext context)
    {
        string correlationId = GetCorrelationId(context);

        string clientId = GetClientId(context);

        try
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                var result = Next.Invoke(context);

                var logFormatted = LogFormatter.Format(context);

                Logger.LogInformation(logFormatted);

                return result;
            }
        }
        catch (Exception ex)
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                var exceptionFormatted = ExceptionFormatter.Format(ex);
                
                Logger.LogError(ex, exceptionFormatted);
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = ProblemDetailsFactory.Create(ex);

            return context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private  string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier ?? "Unknown";
    }

    private  string GetClientId(HttpContext context) =>
        context.User?.FindFirst(ClientIdHeaderName)?.Value ?? "Unknown";
}
