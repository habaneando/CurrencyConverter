using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyValidator : Validator<GetRatesByCurrencyRequest>
{
    public GetRatesByCurrencyValidator()
    {
        RuleFor(x => x.currency)
            .SetValidator(new CurrencyCodeValidator());
    }   
}
