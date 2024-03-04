using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Domain.Requests;

public record NewUserRequest(string Name, string Username, string Email, string Password, Guid? CompanyId, string? CompanyName, UserCompanyRole Role)
{
}
