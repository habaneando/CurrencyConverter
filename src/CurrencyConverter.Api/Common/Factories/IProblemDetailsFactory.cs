using FastEndpoints;

namespace CurrencyConverter.Api;

public interface IProblemDetailsFactory
{
    ProblemDetails Create(Exception ex);
}
