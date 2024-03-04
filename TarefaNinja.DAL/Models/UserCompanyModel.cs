using TarefaNinja.DAL.Abstracts;
using TarefaNinja.Utils.Enums;

namespace TarefaNinja.DAL.Models;

public record UserCompanyModel() : BaseModel
{
    public UserCompanyModel(Guid userId, Guid companyId, UserCompanyRole role) : this()
    {
        UserId = userId;
        CompanyId = companyId;
        Role = role;
    }

    public Guid UserId { get; set; }

    public virtual UserModel User { get; set; } = default!;

    public Guid CompanyId { get; set; }

    public virtual CompanyModel Company { get; set; } = default!;

    public UserCompanyRole Role { get; set; }
}
