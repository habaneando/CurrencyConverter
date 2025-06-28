using FastEndpoints;
using FluentValidation;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyValidator : Validator<GetRatesByCurrencyRequest>
{
    public GetRatesByCurrencyValidator(ICurrencyCodeValidator currencyCodeValidator)
    {
        RuleFor(x => x.currency)
            .SetValidator(currencyCodeValidator as AbstractValidator<string>);
    }   
}
