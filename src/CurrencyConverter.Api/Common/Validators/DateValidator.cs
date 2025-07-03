namespace CurrencyConverter.Api;

public class DateValidator : AbstractValidator<string>, IDateValidator
{
    public DateValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Date cannot be empty.")
            .Custom((value, context) =>
            {
                if (!DateTime.TryParse(value, out var parsedDate))
                {
                    context.AddFailure("Date must be a valid format.");
                }
            });
    }
}
