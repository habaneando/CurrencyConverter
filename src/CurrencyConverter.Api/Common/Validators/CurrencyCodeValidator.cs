namespace CurrencyConverter.Api;

public class CurrencyCodeValidator : AbstractValidator<string>, ICurrencyCodeValidator
{
    public CurrencyCodeValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Currency cannot be empty.")
            .Custom((value, context) =>
            {
                if (CurrencyCode.TryCreate(value) is null)
                {
                    context.AddFailure("Currency must be a valid 3-letter ISO code.");
                }
            });
    }
}
