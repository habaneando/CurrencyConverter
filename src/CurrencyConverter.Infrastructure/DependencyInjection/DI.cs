namespace CurrencyConverter.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IPaymentRepository, PaymentRepository>();

        services.AddScoped<ILoanRepository, LoanRepository>();

        services.AddSingleton<ICurrencyRepository, InMemoryCurrencyRepository>();

        return services;
    }
}
