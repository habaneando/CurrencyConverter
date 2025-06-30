namespace CurrencyConverter.Api;

public record User(
    string Id,
    string Username,
    string Password,
    List<Role> Roles,
    List<Permission> Permissions,
    List<Scope> Scopes);
