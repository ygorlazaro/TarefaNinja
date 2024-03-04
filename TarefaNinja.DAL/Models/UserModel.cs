using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record UserModel(string Name, string Username, string Email, string Password) : BaseModel
{
    public virtual ICollection<UserCompanyModel> UserCompanies { get; set; } = default!;

    public virtual ICollection<ProjectModel> Projects { get; set; } = default!;

    public virtual ICollection<TaskModel> Tasks { get; set; } = default!;

    public virtual ICollection<TaskModel> Following { get; set; } = default!;
}
