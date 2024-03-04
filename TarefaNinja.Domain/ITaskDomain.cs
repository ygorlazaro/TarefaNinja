
using TarefaNinja.Domain.Responses;

namespace TarefaNinja.Domain;

public interface ITaskDomain
{
    Task<ICollection<TaskResponse>> GetByProjectAsync(Guid projectId);
    Task<ICollection<TaskResponse>> GetByUserAsync(Guid userId);
}