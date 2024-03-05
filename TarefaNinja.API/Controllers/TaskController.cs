using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.API.Controllers;

public class TaskController : BaseController
{
    public TaskController(ITaskDomain taskDomain)
    {
        TaskDomain = taskDomain;
    }

    private ITaskDomain TaskDomain { get; }

    [HttpGet]
    public async Task<ActionResult<ICollection<TaskResponse>>> GetTasksAsync()
    {
        var tasks = await TaskDomain.GetByUserAsync(GetUserId());

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> PostAsync([FromBody] NewTaskRequest taskRequest)
    {
        var userId = GetUserId();

        var task = await TaskDomain.CreateTaskAsync(taskRequest, userId);

        return Ok(task);
    }
}
