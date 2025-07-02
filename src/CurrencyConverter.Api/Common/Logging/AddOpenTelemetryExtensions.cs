using Npgsql;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CurrencyConverter.Api;

public static class AddOpenTelemetryExtensions
{
    public static IServiceCollection AddTelemetry(this IServiceCollection services)
    {
        var serviceName = "CurrencyConverterApi";

        var serviceVersion = "1.0.0";

        var outputUrl = new Uri("4317");
        //Add environment variable OTEL_EXPORTER_OTLP_ENDPOINT
        //add OTEL_EXPORTER_OTLP_ENDPOINT to appsettings.json

        //run jaeger locally for testing
        //4317 default port for OTLP gRPC
        //16686 default port for Jaeger UI
        //docker run -d -p 4317:4317 -p 16686:16686 jaegertracing/all-in-one:latest

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
            .WithMetrics(metrics => { })
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
