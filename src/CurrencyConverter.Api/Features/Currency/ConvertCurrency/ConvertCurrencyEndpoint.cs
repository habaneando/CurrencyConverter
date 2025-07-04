﻿namespace CurrencyConverter.Api;

internal class ConvertCurrencyEndpoint(
    IConvertCurrencyService CurrencyRateService,
    IExcludeCurrencyCodeValidator ExcludeCurrencyCodeValidator,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : Endpoint<ConvertCurrencyRequest, ConvertCurrencyResponse, ConvertCurrencyMapper>
{
    public override void Configure()
    {
        Get("/exchange-rates/{currency}/{symbols}/{amount}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        Policies(CurrencyPolicy.Converter);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(ConvertCurrencyRequest convertCurrencyRequest, CancellationToken ct)
    {
        if (ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.currency) ||
            ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.symbols))
        {
            ThrowError("Currency not allowed.");
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
