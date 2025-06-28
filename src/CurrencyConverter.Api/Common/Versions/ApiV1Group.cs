using FastEndpoints;

namespace CurrencyConverter.Api;

public sealed class ApiV1Group : Group
{
    public ApiV1Group()
    {
        Configure("api/v1", ep => { });
    }
}
