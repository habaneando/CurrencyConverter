using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByCurrencyEndpoint(ICurrencyRateService CurrencyRateService) 
    : Endpoint<GetRatesByCurrencyRequest, GetRatesByCurrencyResponse, GetRatesByCurrencyMapper>
{
    public override void Configure()
    {
        Get("/rate2/{base}");
        AllowAnonymous();
        
    }

    public override async Task HandleAsync(GetRatesByCurrencyRequest req, CancellationToken ct)
    {
        var currentRate = await CurrencyRateService.GetRatesByCurrencyAsync(req.@base);

        var getRatesResponse = Map.FromEntity(currentRate);

        await SendOkAsync(getRatesResponse, ct).ConfigureAwait(false);
    }
}
