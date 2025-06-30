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
    .AddThrottling()
    .AddFastEndpoints()
    .AddAntiforgery()
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

app.UseHttpsRedirection()
   .UseAntiforgeryFE()
   .UseAuthentication()
   .UseFastEndpoints(c =>
   {
       c.Endpoints.Configurator = ep =>
       {
           ep.PreProcessors(Order.Before, typeof(RequestLogger<>));
           ep.PostProcessors(Order.After, typeof(ResponseLogger<,>)); 
       };
   });
   

await app.RunAsync()
    .ConfigureAwait(false);
