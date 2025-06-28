using FastEndpoints;

namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyValidator : Validator<GetRatesByCurrencyRequest>
{
    public GetRatesByCurrencyValidator(CurrencyCodeValidator currencyCodeValidator)
    {
        RuleFor(x => x.currency)
            .SetValidator(currencyCodeValidator);
    }   
}
