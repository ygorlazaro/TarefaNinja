using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record CompanyModel(string Name) : BaseModel
{
    public CompanyModel(Guid id, string Name) : this(Name)
    {
        Id = id;
    }

    public virtual ICollection<UserCompanyModel> UserCompanies { get; set; } = default!;
}
