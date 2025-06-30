namespace CurrencyConverter.Api;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.BuildServiceProvider()
            .GetService<IAuthorizationPolicyProvider>()?
                .GetPolicies()
                    .ForEach(policy =>
                        services.AddAuthorization(options =>
                            options.AddPolicy(policy.Name, policy.ConfigurePolicy)));

        return services;
    }
}
