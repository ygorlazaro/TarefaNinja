using TarefaNinja.Domain.Responses;

namespace TarefaNinja.Domain;

public interface IProjectDomain
{
    Task<ICollection<ProjectResponse>> GetByUserAsync(Guid userId);
    Task<ICollection<ProjectResponse>> GetProjectsAsync(Guid companyId);
}
