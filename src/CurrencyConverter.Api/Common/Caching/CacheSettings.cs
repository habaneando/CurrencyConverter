namespace CurrencyConverter.Api;

public class CacheSettings(IConfiguration configuration)
{
    public int CacheDurationInSeconds =>
        configuration.GetSection("CacheSettings:DefaultCacheDurationSeconds").Get<int>();

    public TimeSpan CacheDuration =>
        TimeSpan.FromSeconds(CacheDurationInSeconds);
}
