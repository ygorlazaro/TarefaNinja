using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public interface ILabelRepository : IBaseRepository<LabelModel>
{
    Task<ICollection<LabelModel>> GetByProjectAsync(Guid projectId);
}
