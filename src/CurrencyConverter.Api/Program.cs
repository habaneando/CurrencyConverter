using CurrencyConverter.Api;
using CurrencyConverter.Application;
using CurrencyConverter.Domain;
using CurrencyConverter.Infrastructure;
using FastEndpoints;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddOpenApi();

builder.Services.AddRefitClient<ICurrencyRateService>(
    new RefitSettings
    {
        ContentSerializer = new SystemTextJsonContentSerializer(
            new JsonSerializerOptions
            {
                Converters = { new DateTimeYyyyMMddConverter() },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            })
    })
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.frankfurter.dev"));

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure("");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.AddSwagger();

    app.AddScalar();

    app.AddReDoc(); 
}

app.UseHttpsRedirection();

app.UseFastEndpoints();

await app.RunAsync().ConfigureAwait(false);
