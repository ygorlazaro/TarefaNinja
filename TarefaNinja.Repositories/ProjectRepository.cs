using Microsoft.EntityFrameworkCore;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class ProjectRepository : BaseRepository<ProjectModel>, IProjectRepository
{
    public ProjectRepository(DefaultContext context) : base(context)
    {

    }

    public async Task<ICollection<ProjectModel>> GetProjectsByCompanyAsync(Guid companyId)
    {
        var query = from project in Context.Projects
                    where project.CompanyId == companyId
                    orderby project.Name
                    select new ProjectModel(project.Id, project.Name, project.Status);

        return await query.ToListAsync();
    }
}
