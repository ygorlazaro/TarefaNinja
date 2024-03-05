using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Utils.Responses;

public record ProjectResponse(Guid Id, string Name, ProjectStatus Status);