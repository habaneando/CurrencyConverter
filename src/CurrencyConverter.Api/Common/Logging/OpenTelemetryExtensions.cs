namespace CurrencyConverter.Api;

public static class OpenTelemetryExtensions
{
    /// <summary>
    /// Add environment variable OTEL_EXPORTER_OTLP_ENDPOINT
    /// add OTEL_EXPORTER_OTLP_ENDPOINT to appsettings.json
    /// run jaeger locally for testing
    /// 4317 default port for OTLP gRPC
    /// 16686 default port for Jaeger UI
    /// docker run -d -p 4317:4317 -p 16686:16686 jaegertracing/all-in-one:latest
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddTelemetry(this IServiceCollection services)
    {
        var serviceName = "CurrencyConverterApi";

        var serviceVersion = "1.0.0";

        var outputUrl = new Uri("http://localhost:4317");

        services
            .AddOpenTelemetry()
            .ConfigureResource(resource =>
                resource.AddService(serviceName, serviceVersion))
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddRedisInstrumentation()
                    .AddNpgsql()
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = outputUrl;
                        options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
                    });
            })
            .WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddNpgsqlInstrumentation()
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = outputUrl;
                        options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
                    });
            })
            .WithLogging(logging =>
            {
                logging.AddProcessor<CustomLogProcessor>();

                logging.AddOtlpExporter(opt =>
                {
                    opt.Endpoint = outputUrl;
                });
            });

        return services;
    }
}
