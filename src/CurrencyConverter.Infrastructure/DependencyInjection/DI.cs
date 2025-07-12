namespace CurrencyConverter.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ILoanRepository>(sp =>
            new InMemoryLoanRepository(InMemoryLoanRepositorySeed.Data));

        services.AddScoped<IPaymentRepository>(sp =>
            new InMemoryPaymentRepository(InMemoryPaymentRepositorySeed.Data));

        services.AddScoped<ICustomerRepository>(sp =>
            new InMemoryCustomerRepository(InMemoryCustomerRepositorySeed.Data));

        services.AddSingleton<ICurrencyRepository, InMemoryCurrencyRepository>();

        return services;
    }
}
