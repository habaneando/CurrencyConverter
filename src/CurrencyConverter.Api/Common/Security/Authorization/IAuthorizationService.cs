namespace CurrencyConverter.Api;

public interface IAuthorizationService
{
    Task<List<Claim>> GetUserClaimsAsync(string userId, CancellationToken ct);
}
