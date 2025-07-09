namespace CurrencyConverter.Application;

public class CurrencyCodeValidator : AbstractValidator<string>, ICurrencyCodeValidator
{
    public CurrencyCodeValidator(Currency2.Factory currencyFactory)
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Currency cannot be empty.")
            .Custom((value, context) =>
            {
                if (currencyFactory.Create(value).GetAwaiter().GetResult() is null)
                {
                    context.AddFailure("Currency must be a valid 3-letter ISO code.");
                }
            });
    }
}
