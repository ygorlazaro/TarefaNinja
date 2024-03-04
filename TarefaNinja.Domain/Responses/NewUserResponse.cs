using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Domain.Responses;

public record NewUserResponse(Guid UserId, string Name, string Login, string Email, Guid CompanyId, string CompanyName, UserCompanyRole Role)
{

}
