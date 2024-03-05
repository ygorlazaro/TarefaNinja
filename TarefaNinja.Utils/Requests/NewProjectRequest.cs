using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Utils.Requests;

public record NewProjectRequest(Guid CompanyId, string Name, ProjectStatus Status);