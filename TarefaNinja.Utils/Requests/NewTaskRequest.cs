using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Utils.Requests;

public record NewTaskRequest(string Name, string Descrption, ProjectTaskStatus Status, Guid ProjectId);
