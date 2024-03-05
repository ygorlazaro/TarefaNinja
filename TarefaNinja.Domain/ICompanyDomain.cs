using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public interface ICompanyDomain
{
    Task<CompanyUserResponse?> CreateCompanyAsync(NewCompanyRequest companyUserRequest, Guid userId);
    Task<ICollection<CompanyUserResponse>> GetByUserAsync(Guid userId);
}
