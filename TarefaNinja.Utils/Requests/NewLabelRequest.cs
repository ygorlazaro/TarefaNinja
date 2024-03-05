namespace TarefaNinja.Utils.Requests;

public record NewLabelRequest(string Name, string Color, Guid ProjectId);