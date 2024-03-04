using TarefaNinja.DAL.Abstracts;
using TarefaNinja.Utils.Enums;

namespace TarefaNinja.DAL.Models;

public record ProjectModel(string Name, ProjectStatus Status) : BaseModel
{
    public ProjectModel(Guid id, string name, ProjectStatus status) : this(name, status)
    {
        Id = id;
    }

    public Guid OwnerId { get; set; }

    public virtual UserModel Owner { get; set; } = default!;

    public Guid CompanyId { get; set; }

    public virtual CompanyModel Company { get; set; } = default!;

    public virtual ICollection<TaskModel> Tasks { get; set; } = default!;

    public virtual ICollection<LabelModel> Labels { get; set; } = default!;
}
