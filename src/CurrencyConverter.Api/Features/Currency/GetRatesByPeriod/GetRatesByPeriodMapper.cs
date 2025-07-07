namespace CurrencyConverter.Api;

internal sealed class GetRatesByPeriodMapper : ResponseMapper<BaseResponse, GetRatesByPeriodResponse>
{
    public BaseResponse FromEntity(GetRatesByPeriodResponse getRatesByPeriodResponse) =>
        new(getRatesByPeriodResponse);
}
