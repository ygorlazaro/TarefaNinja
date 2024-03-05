namespace TarefaNinja.Utils.Responses;

public record UserLoginResponse(Guid userId, string Name, string Login, string Email);
