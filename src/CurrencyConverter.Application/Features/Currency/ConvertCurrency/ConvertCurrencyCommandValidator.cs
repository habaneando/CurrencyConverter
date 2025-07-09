namespace CurrencyConverter.Application;

public class ConvertCurrencyCommandValidator
    : AbstractValidator<ConvertCurrencyCommand>
{

    public ConvertCurrencyCommandValidator(IExcludedCurrencyValidator ExcludeCurrencyValidator)
    {
        //if (ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.currency) ||
        //    ExcludeCurrencyCodeValidator.IsNotAllowed(convertCurrencyRequest.symbols))
        //{
        //    ThrowError("Currency not allowed.");
        //}

        //RuleFor(x => x.currency)
        //    .SetValidator(currencyCodeValidator as AbstractValidator<string>);
        //RuleFor(x => x.symbols)
        //    .SetValidator(currencyCodeValidator as AbstractValidator<string>);
    }
}
