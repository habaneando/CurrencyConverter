namespace CurrencyConverter.Api;

internal sealed class GetRatesByCurrencyMapper : ResponseMapper<BaseResponse, GetRatesByCurrencyResponse>
{
    public BaseResponse FromEntity(GetRatesByCurrencyResponse getRatesByCurrencyResponse) =>
        new(getRatesByCurrencyResponse);
}
