using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Utils.Responses;

public record TaskResponse(Guid Id, string Name, ProjectTaskStatus Status, Guid UserId, string UserName, string Email)
{
}