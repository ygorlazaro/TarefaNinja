using TarefaNinja.Domain.Responses;
using TarefaNinja.Repositories;

namespace TarefaNinja.Domain;

public class TaskDomain : ITaskDomain
{
    public TaskDomain(ITaskRepository taskRepository)
    {
        TaskRepository = taskRepository;
    }

    private ITaskRepository TaskRepository { get; }

    public async Task<ICollection<TaskResponse>> GetTasksAsync(Guid projectId)
    {
        var tasks = await TaskRepository.GetByProjectAsync(projectId);

        return tasks.Select(task => new TaskResponse(task.Id, task.Name, task.Status, task.Assignee.Id, task.Assignee.Name, task.Assignee.Email)).ToList();
    }
}

