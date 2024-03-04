using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class ProjectRepository: BaseRepository<ProjectModel>, IProjectRepository
{
    public ProjectRepository(DefaultContext context) : base(context)
    {
        
    }
}
