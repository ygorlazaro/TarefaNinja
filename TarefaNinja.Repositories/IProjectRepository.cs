using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public interface IProjectRepository : IBaseRepository<ProjectModel>
{
    Task<ICollection<ProjectModel>> GetByUserAsync(Guid userId);
    Task<ICollection<ProjectModel>> GetProjectsByCompanyAsync(Guid companyId);
}
