using CurrencyConverter.Api;
using CurrencyConverter.Application;
using CurrencyConverter.Domain;
using CurrencyConverter.Infrastructure;
using FastEndpoints;
using FastEndpoints.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddDomain()
    .AddApplication()
    .AddInfrastructure()
    .AddApi();

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens") 
    .AddAuthorizationPolicies()
    .AddFastEndpoints()
    .AddResponseCaching();

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

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints();

await app.RunAsync()
    .ConfigureAwait(false);
