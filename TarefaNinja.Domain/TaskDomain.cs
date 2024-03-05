using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public class TaskDomain : ITaskDomain
{
    public TaskDomain(ITaskRepository taskRepository)
    {
        TaskRepository = taskRepository;
    }

    private ITaskRepository TaskRepository { get; }

    public async Task<ICollection<TaskResponse>> GetByProjectAsync(Guid projectId)
    {
        var tasks = await TaskRepository.GetByProjectAsync(projectId);
        return Map(tasks);
    }

    public async Task<ICollection<TaskResponse>> GetByUserAsync(Guid userId)
    {
        var tasks = await TaskRepository.GetByUserAsync(userId);

        return Map(tasks);
    }

    private static ICollection<TaskResponse> Map(ICollection<TaskModel> tasks)
    {
        return tasks.Select(task => new TaskResponse(task.Id, task.Name, task.Status, task.Assignee.Id, task.Assignee.Name, task.Assignee.Email)).ToList();
    }

    public async Task<TaskResponse> CreateTaskAsync(NewTaskRequest taskRequest, Guid userId)
    {
        var task = await TaskRepository.InsertAsync(new TaskModel(taskRequest.Name, taskRequest.Descrption, taskRequest.Status, userId));
        var taskWithDetails = await TaskRepository.GetByIdAsync(task.Id);

        ArgumentNullException.ThrowIfNull(taskWithDetails);

        return new TaskResponse(taskWithDetails.Id, taskWithDetails.Name, taskWithDetails.Status, taskWithDetails.Assignee.Id, taskWithDetails.Assignee.Name, taskWithDetails.Assignee.Email);
    }
}

