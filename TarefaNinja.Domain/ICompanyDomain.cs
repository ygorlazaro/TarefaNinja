using TarefaNinja.Domain.Responses;

namespace TarefaNinja.Domain;

public interface ICompanyDomain
{
    Task<ICollection<CompanyUserResponse>> GetByUserAsync(Guid userId);
}
