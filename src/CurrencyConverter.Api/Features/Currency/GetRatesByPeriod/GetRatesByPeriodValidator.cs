using FastEndpoints;
using FluentValidation;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByPeriodValidator : Validator<GetRatesByPeriodRequest>
{
    public GetRatesByPeriodValidator(IDateValidator dateValidator, ICurrencyCodeValidator currencyCodeValidator)
    {
        RuleFor(x => x.from)
            .SetValidator(dateValidator as AbstractValidator<string>);
        RuleFor(x => x.to)
            .SetValidator(dateValidator as AbstractValidator<string>);
        RuleFor(x => x.currency)
            .SetValidator(currencyCodeValidator as AbstractValidator<string>);
    }
}
