using TarefaNinja.DAL.Abstracts;
using TarefaNinja.Utils.Enums;

namespace TarefaNinja.DAL.Models;

public record TaskModel(string Name, string Description, ProjectTaskStatus Status) : BaseModel
{
    public TaskModel(Guid id, string name, ProjectTaskStatus status, UserModel userModel) : this(name, string.Empty, status)
    {
        Id = id;
        Assignee = userModel;
    }

    public Guid? AssigneeId { get; set; }

    public virtual UserModel Assignee { get; set; } = default!;

    public Guid ProjectId { get; set; }

    public virtual ProjectModel Project { get; set; } = default!;

    public virtual ICollection<UserModel> Followers { get; set; } = default!;
}
