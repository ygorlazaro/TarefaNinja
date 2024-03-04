using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class TaskRepository: BaseRepository<TaskModel>, ITaskRepository
{
    public TaskRepository(DefaultContext context) : base(context)
    {
        
    }
}
