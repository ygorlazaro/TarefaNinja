using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Domain.Responses;

namespace TarefaNinja.API.Controllers;

public class ProjectController : BaseController
{
    public ProjectController(ITaskDomain taskDomain)
    {
        TaskDomain = taskDomain;
    }

    private ITaskDomain TaskDomain { get; }

    [HttpGet("{projectId/task}")]
    public async Task<ActionResult<ICollection<TaskResponse>>> GetTasksAsync([FromRoute] Guid projectId)
    {
        var tasks = await TaskDomain.GetTasksAsync(projectId);

        return Ok(tasks);
    }
}
