using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record LabelModel(string Name, string Color): BaseModel
{
    public Guid ProjectId { get; set; }

    public virtual ProjectModel Project { get; set; } = default!;
}
