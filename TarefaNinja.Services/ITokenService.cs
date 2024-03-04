namespace TarefaNinja.Services;

public interface ITokenService
{
    string GenerateJwtToken(string login, string name, Guid userId, string email, string jwtKey, string jwtIssuer, string jwtAudience);
}
