using TarefaNinja.DAL.Abstracts;

namespace TarefaNinja.DAL.Models;

public record CompanyModel(string Name) : BaseModel
{
    public virtual ICollection<UserCompanyModel> UserCompanies { get; set; } = default!;
}
