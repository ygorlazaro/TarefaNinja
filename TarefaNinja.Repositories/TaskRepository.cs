using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class TaskRepository : BaseRepository<TaskModel>, ITaskRepository
{
    public TaskRepository(DefaultContext context) : base(context)
    {

    }

    public async Task<ICollection<TaskModel>> GetByProjectAsync(Guid projectId)
    {
        var query = from task in Context.Tasks
                    join user in Context.Users on task.AssigneeId equals user.Id
                    where task.ProjectId == projectId
                    select new TaskModel(task.Id, task.Name, task.Status, new UserModel(user.Id, user.Name, user.Email));

        return await query.ToListAsync();
    }

    public async Task<ICollection<TaskModel>> GetByUserAsync(Guid userId)
    {
        var query = from task in Context.Tasks
                    join user in Context.Users on task.AssigneeId equals user.Id
                    where task.AssigneeId == userId
                    select new TaskModel(task.Id, task.Name, task.Status, new UserModel(user.Id, user.Name, user.Email));

        return await query.ToListAsync();
    }

    public override async Task<TaskModel?> GetByIdAsync(Guid taskId)
    {
        var query = from task in Context.Tasks
                    join user in Context.Users on task.AssigneeId equals user.Id
                    where task.Id == taskId
                    select new TaskModel(task.Id, task.Name, task.Status, new UserModel(user.Id, user.Name, user.Email));

        return await query.FirstOrDefaultAsync();
    }
}
