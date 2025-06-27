using CurrencyConverter.Domain;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal class GetRatesByCurrencyEndpoint 
    : Endpoint<GetRatesByCurrencyRequest, GetRatesByCurrencyResponse, GetRatesByCurrencyMapper>
{
    public override void Configure()
    {
        Get("/rate/{currency}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRatesByCurrencyRequest req, CancellationToken ct)
    {
        var currencyRate = new CurrencyRate(
            req.currency,
            DateTime.Today.ToString(new CultureInfo("en-US")),
            new List<Money>());

        if (currencyRate.Base is null)
        {
            await SendNotFoundAsync(ct).ConfigureAwait(false);
            return;
        }

        var response = Map.FromEntity(currencyRate);

        await SendOkAsync(response, ct).ConfigureAwait(false);
    }
}
