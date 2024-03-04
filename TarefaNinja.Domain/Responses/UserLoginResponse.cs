namespace TarefaNinja.Domain.Responses;

public record UserLoginResponse(Guid userId, string Name, string Username, string Email);
