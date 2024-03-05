using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public interface IProjectDomain
{
    Task<ProjectResponse> CreateProject(NewProjectRequest projectRequest, Guid userId);
    Task<ICollection<ProjectResponse>> GetByUserAsync(Guid userId);
    Task<ICollection<ProjectResponse>> GetProjectsAsync(Guid companyId);
}
