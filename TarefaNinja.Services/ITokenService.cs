namespace TarefaNinja.Services;

public interface ITokenService
{
    string GenerateJwtToken(string userName, string name, Guid userId, string email, string jwtKey, string jwtIssuer, string jwtAudience);
}
