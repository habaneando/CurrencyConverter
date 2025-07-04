using GeneratedCode;

var builder = WebApplication.CreateBuilder(args);

//builder.ConfigureServices((context, services) =>
//{
//    var configuration = context.Configuration;

//    builder.Services.ConfigureAppSettings(configuration);
//});

var sample = new SampleClass4();

builder.Services
    .AddOpenApi()
    .AddDomain()
    .AddApplication()
    .AddInfrastructure()
    .AddApi();

builder.Services
    .AddJwtAuthentication()
    .AddAuthorizationPolicies()
    .AddThrottling()
    .AddFastEndpoints()
    .AddAntiforgery()
    .AddResponseCaching()
    .AddTelemetry();

builder.AddSerilog();

var app = builder.Build();

//app.Services.ValidateConfiguration();

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
   })
   .UseSerilogRequestLogging()
   .AddCorrelationIdToRequest();

await app.RunAsync()
    .ConfigureAwait(false);
