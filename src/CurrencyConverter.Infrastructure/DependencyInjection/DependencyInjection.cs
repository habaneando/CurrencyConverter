using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        return services;
    }
}