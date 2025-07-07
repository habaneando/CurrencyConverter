using FluentValidation;

namespace CurrencyConverter.Application;

public class GetRatesQueryValidator : AbstractValidator<GetRatesQuery>
{
    public GetRatesQueryValidator()
    {
        
    }
}
