
using TarefaNinja.DAL.Models;
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

        return Map(projects);
    }

    public async Task<ICollection<ProjectResponse>> GetByUserAsync(Guid userId)
    {
        var projects = await ProjectRepository.GetByUserAsync(userId);

        return Map(projects);
    }

    private static List<ProjectResponse> Map(ICollection<ProjectModel> projects)
    {
        return projects.Select(project => new ProjectResponse(project.Id, project.Name, project.Status)).ToList();
    }
}
