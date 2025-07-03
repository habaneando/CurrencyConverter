using System.Security.Claims;

namespace CurrencyConverter.Api;

public record UserLoginResponse(
    string Token,
    string UserId,
    string Username,
    List<Role> Roles,
    List<Claim> Claims);
