using Microsoft.EntityFrameworkCore;

using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class LabelRepository : BaseRepository<LabelModel>, ILabelRepository
{
    public LabelRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<ICollection<LabelModel>> GetByProjectAsync(Guid projectId)
    {
        var query = from label in Context.Labels
                    where label.ProjectId == projectId
                    select new LabelModel(label.Id, label.Name, label.Color);

        return await query.ToListAsync();
    }
}
