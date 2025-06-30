using FastEndpoints;

namespace CurrencyConverter.Api;

public class RequestLogger<TRequest> : IPreProcessor<TRequest>
{
    public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
    {
        var logger = ctx.HttpContext.Resolve<ILogger<TRequest>>();

        var clientIp = ctx.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        var clientId = ctx.HttpContext.User?.FindFirst("client_id")?.Value ?? "Unknown";
        var traceId = ctx.HttpContext.TraceIdentifier;
        var correlationId = ctx.HttpContext.Request.Headers["X-Correlation-ID"].FirstOrDefault();
        var httpMethod = ctx.HttpContext.Request.Method;
        var endpoint = ctx.HttpContext.Request.Path;
        var statusCode = ctx.HttpContext.Response.StatusCode;

        logger.LogInformation(
            $"request:{ctx.Request.GetType().FullName} path: {ctx.HttpContext.Request.Path}");

        return Task.CompletedTask;
    }
}
