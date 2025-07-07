namespace CurrencyConverter.Application;

public sealed record ConvertCurrencyHandler
(
    IConvertCurrencyService ConvertCurrencyService,
    ConvertCurrencyCommandValidator ConvertCurrencyCommandValidator
) : ICommandHandler<ConvertCurrencyCommand, ConvertCurrencyResponse>
{
    public async Task<ConvertCurrencyResponse> Handle(ConvertCurrencyCommand convertCurrencyCommand, CancellationToken cancellationToken)
    {
        var validation = await ConvertCurrencyCommandValidator
            .ValidateAsync(convertCurrencyCommand, cancellationToken)
            .ConfigureAwait(false);

        if (!validation.IsValid)
        {
            throw new BusinessValidationException(
                string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
        }

        var currencyRates = await ConvertCurrencyService.ConvertCurrencyAsync(
            convertCurrencyCommand.Currency,
            convertCurrencyCommand.Symbols,
            convertCurrencyCommand.Amount)
            .ConfigureAwait(false);

        var response = new ConvertCurrencyResponse
        {
            Amount = currencyRates.Amount,
            Base = currencyRates.Base,
            Date = currencyRates.Date,
            Rates = currencyRates.Rates
        };

        return response;
    }
}
