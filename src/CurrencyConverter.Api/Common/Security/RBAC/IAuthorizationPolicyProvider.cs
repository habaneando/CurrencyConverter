namespace CurrencyConverter.Api;

public interface IAuthorizationPolicyProvider
{
    List<AuthorizationPolicy> GetPolicies();
}
