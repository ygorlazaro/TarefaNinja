using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;
using TarefaNinja.Utils.Enums;

namespace TarefaNinja.Repositories;

public interface ICompanyRepository : IBaseRepository<CompanyModel>
{
    Task<bool> AddUserToCompanyAsync(Guid userId, Guid companyId, UserCompanyRole role);
}
