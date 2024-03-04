using TarefaNinja.DAL;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories.Abstracts;

namespace TarefaNinja.Repositories;

public class LabelRepository : BaseRepository<LabelModel>, ILabelRepository
{
    public LabelRepository(DefaultContext context) : base(context)
    {
    }
}
