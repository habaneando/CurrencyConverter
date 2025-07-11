﻿namespace CurrencyConverter.Api;

public static class SerilogExtensions
{
    public static IHostBuilder AddSerilog(this WebApplicationBuilder builder) =>
        builder.Host.UseSerilog((context, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(context.Configuration));

    public static IApplicationBuilder AddCorrelationIdToRequest(this IApplicationBuilder app) =>
        app.UseMiddleware<AddCorrelationIdAndClientIdToRequestMiddleware>();
}
