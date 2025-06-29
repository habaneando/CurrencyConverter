using CurrencyConverter.Api;
using CurrencyConverter.Application;
using CurrencyConverter.Domain;
using CurrencyConverter.Infrastructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints()
    .AddResponseCaching();

builder.Services.AddOpenApi();

builder.Services.AddDomain();

builder.Services.AddApplication();

builder.Services.AddInfrastructure("");

builder.Services.AddApi();

var app = builder.Build();

app.UseResponseCaching();

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
