
using TarefaNinja.Domain.Responses;
using TarefaNinja.Repositories;

namespace TarefaNinja.Domain;

public class ProjectDomain : IProjectDomain
{
    private IProjectRepository ProjectRepository { get; }

    public ProjectDomain(IProjectRepository projectRepository)
    {
        ProjectRepository = projectRepository;
    }

    public async Task<ICollection<ProjectResponse>> GetProjectsAsync(Guid companyId)
    {
        var projects = await ProjectRepository.GetProjectsByCompanyAsync(companyId);

        return projects.Select(project => new ProjectResponse(project.Id, project.Name, project.Status)).ToList();
    }
}
