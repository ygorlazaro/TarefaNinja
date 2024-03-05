using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public interface ITaskDomain
{
    Task<TaskResponse> CreateTaskAsync(NewTaskRequest taskRequest, Guid userId);
    Task<ICollection<TaskResponse>> GetByProjectAsync(Guid projectId);
    Task<ICollection<TaskResponse>> GetByUserAsync(Guid userId);
}
