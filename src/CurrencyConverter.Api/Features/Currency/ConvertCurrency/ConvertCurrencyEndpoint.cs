using FastEndpoints;

namespace CurrencyConverter.Api;

internal class ConvertCurrencyEndpoint(IConvertCurrencyService CurrencyRateService) 
    : Endpoint<ConvertCurrencyRequest, ConvertCurrencyResponse, ConvertCurrencyMapper>
{
    public override void Configure()
    {
        Get("/exchange-rates/{currency}/{symbols}/{amount}");
        Group<ApiV1Group>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(ConvertCurrencyRequest convertCurrencyRequest, CancellationToken ct)
    {
        var currentRate = await CurrencyRateService.ConvertCurrencyAsync(
            convertCurrencyRequest.currency,
            convertCurrencyRequest.symbols,
            convertCurrencyRequest.amount)
            .ConfigureAwait(false);

        var getRatesResponse = Map.FromEntity(currentRate);

        await SendOkAsync(getRatesResponse, ct)
            .ConfigureAwait(false);
    }
}
