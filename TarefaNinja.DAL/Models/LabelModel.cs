using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record LabelModel(string Name, string Color) : BaseModel
{
    public LabelModel(Guid id, string name, string color) : this(name, color)
    {
        Id = id;
    }

    public LabelModel(string Name, string Color, Guid projectId) : this(Name, Color)
    {
        ProjectId = projectId;
    }

    public Guid ProjectId { get; set; }

    public virtual ProjectModel Project { get; set; } = default!;
}
