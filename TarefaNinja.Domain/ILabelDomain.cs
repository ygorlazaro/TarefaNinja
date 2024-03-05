using TarefaNinja.API.Controllers;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public interface ILabelDomain
{
    Task<ICollection<LabelResponse>> GetByProjectAsync(Guid projectId);

    Task<LabelResponse> InsertAsync(NewLabelRequest labelRequest);
}
