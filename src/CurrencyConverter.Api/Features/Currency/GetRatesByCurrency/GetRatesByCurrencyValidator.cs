using FastEndpoints;
using FluentValidation;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyValidator : Validator<GetRatesByCurrencyRequest>
{
    public GetRatesByCurrencyValidator()
    {
        RuleFor(x => x.@base)
            .NotEmpty()
            .WithMessage("Currency cannot be empty.")
            .Matches(@"^[A-Z]{3}$")
            .WithMessage("Currency must be a valid 3-letter ISO code.");
    }   
}
