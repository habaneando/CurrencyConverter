using CurrencyConverter.Api;
using CurrencyConverter.Application;
using CurrencyConverter.Domain;
using CurrencyConverter.Infrastructure;
using FastEndpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddOpenApi();

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure("");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseFastEndpoints();

await app.RunAsync().ConfigureAwait(false);
