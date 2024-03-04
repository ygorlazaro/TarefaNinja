
using TarefaNinja.Domain.Responses;

namespace TarefaNinja.Domain;

public interface ITaskDomain
{
    Task<ICollection<TaskResponse>> GetTasksAsync(Guid projectId);
}