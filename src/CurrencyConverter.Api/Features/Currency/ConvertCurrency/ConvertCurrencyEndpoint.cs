using System.Net;
using FastEndpoints;

namespace CurrencyConverter.Api;

internal class ConvertCurrencyEndpoint(
    IConvertCurrencyService CurrencyRateService,
    IExcludeCurrencyCodeValidator ExcludeCurrencyCodeValidator,
    CacheSettings CacheSettings) 
    : Endpoint<ConvertCurrencyRequest, ConvertCurrencyResponse, ConvertCurrencyMapper>
{
    public override void Configure()
    {
        Get("/exchange-rates/{currency}/{symbols}/{amount}");
        Group<ApiV1Group>();
        AllowAnonymous();
        ResponseCache(CacheSettings.CacheDurationInSeconds);
        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));
    }

    public override async Task HandleAsync(ConvertCurrencyRequest convertCurrencyRequest, CancellationToken ct)
    {
        if (ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.currency) ||
            ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.symbols))
        {
            AddError("Currency not allowed.");

            await SendErrorsAsync((int)HttpStatusCode.BadRequest, ct);

            return;
        }

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
