namespace CurrencyConverter.Api;

internal sealed class ConvertCurrencyValidator : Validator<ConvertCurrencyRequest>
{
    public ConvertCurrencyValidator(ICurrencyCodeValidator currencyCodeValidator)
    {
        RuleFor(x => x.currency)
            .SetValidator(currencyCodeValidator as AbstractValidator<string>);
        RuleFor(x => x.symbols)
            .SetValidator(currencyCodeValidator as AbstractValidator<string>);
        RuleFor(x => x.amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero.");
    }   
}
