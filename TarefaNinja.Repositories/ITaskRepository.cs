using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public interface ITaskRepository : IBaseRepository<TaskModel>
{
    Task<ICollection<TaskModel>> GetByProjectAsync(Guid projectId);
}
