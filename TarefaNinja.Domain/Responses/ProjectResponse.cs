using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Domain.Responses;

public record ProjectResponse(Guid Id, string Name, ProjectStatus Status);