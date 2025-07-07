namespace CurrencyConverter.Api;

internal class ConvertCurrencyEndpoint(
    Application.ICommandHandler<ConvertCurrencyCommand, ConvertCurrencyResponse> Handler,
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings) 
    : Endpoint<ConvertCurrencyRequest, BaseResponse, ConvertCurrencyMapper>
{
    public override void Configure()
    {
        Get("/exchange-rates/{currency}/{symbols}/{amount}");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(CurrencyPolicy.Converter);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(ConvertCurrencyRequest convertCurrencyRequest, CancellationToken ct)
    {
        var command = new ConvertCurrencyCommand(
            convertCurrencyRequest.currency,
            convertCurrencyRequest.symbols,
            convertCurrencyRequest.amount);

        var response = await Handler.Handle(command, ct);

        var map = Map.FromEntity(response);

        await SendOkAsync(map, ct)
            .ConfigureAwait(false);
    }
}
