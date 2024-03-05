
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

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

    public async Task<ProjectResponse> CreateProject(NewProjectRequest projectRequest, Guid userId)
    {
        var project = await ProjectRepository.InsertAsync(new ProjectModel(projectRequest.Name, projectRequest.CompanyId, userId));

        return new ProjectResponse(project.Id, project.Name, project.Status);
    }
}
