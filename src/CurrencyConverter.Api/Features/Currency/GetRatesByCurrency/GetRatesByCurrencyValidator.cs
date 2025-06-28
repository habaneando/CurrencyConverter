using CurrencyConverter.Domain;
using FastEndpoints;
using FluentValidation;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyValidator : Validator<GetRatesByCurrencyRequest>
{
    public GetRatesByCurrencyValidator()
    {
        RuleFor(x => x.currency)
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
