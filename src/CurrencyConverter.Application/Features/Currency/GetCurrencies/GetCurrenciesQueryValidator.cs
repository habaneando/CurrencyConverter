using FluentValidation;

namespace CurrencyConverter.Application;

public class GetCurrenciesQueryValidator: AbstractValidator<GetCurrenciesQuery>
{
    public GetCurrenciesQueryValidator()
    {
        
    }
}
