using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.API.Controllers;

public class ProjectController : BaseController
{
    public ProjectController(ITaskDomain taskDomain, IProjectDomain projectDomain)
    {
        TaskDomain = taskDomain;
        ProjectDomain = projectDomain;
    }

    private ITaskDomain TaskDomain { get; }
    private IProjectDomain ProjectDomain { get; }

    [HttpGet("{projectId}/task")]
    public async Task<ActionResult<ICollection<TaskResponse>>> GetTasksAsync([FromRoute] Guid projectId)
    {
        var tasks = await TaskDomain.GetByProjectAsync(projectId);

        return Ok(tasks);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<ProjectResponse>>> GetProjectsAsync()
    {
        var projects = await ProjectDomain.GetByUserAsync(GetUserId());

        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> PostAsync([FromBody] NewProjectRequest projectRequest)
    {
        var userId = GetUserId();

        var project = await ProjectDomain.CreateProject(projectRequest, userId);

        if (project is null)
        {
            return BadRequest();
        }

        return Ok(project);
    }
}
