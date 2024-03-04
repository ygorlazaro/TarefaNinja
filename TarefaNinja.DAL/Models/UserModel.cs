using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record UserModel(Guid Id, string Name, string Email) : BaseModel
{
    public UserModel(string name, string login, string email, string password) : this(Guid.Empty, name, email)
    {
        Login = login;
        Password = password;
    }

    public UserModel(Guid id, string name, string login, string email, string password) : this(name, login, email, password)
    {
        Id = id;
    }

    public string Login { get; set; } = default!;

    public string Password { get; set; } = default!;

    public virtual ICollection<UserCompanyModel> UserCompanies { get; set; } = default!;

    public virtual ICollection<ProjectModel> Projects { get; set; } = default!;

    public virtual ICollection<TaskModel> Tasks { get; set; } = default!;

    public virtual ICollection<TaskModel> Following { get; set; } = default!;
}
