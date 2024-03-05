using TarefaNinja.API.Controllers;
using TarefaNinja.DAL.Models;
using TarefaNinja.Repositories;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.Domain;

public class LabelDomain : ILabelDomain
{
    public LabelDomain(ILabelRepository labelRepository)
    {
        LabelRepository = labelRepository;
    }

    private ILabelRepository LabelRepository { get; }

    public async Task<ICollection<LabelResponse>> GetByProjectAsync(Guid projectId)
    {
        var labels = await LabelRepository.GetByProjectAsync(projectId);

        return Map(labels);
    }

    public async Task<LabelResponse> InsertAsync(NewLabelRequest labelRequest)
    {
        var label = await LabelRepository.InsertAsync(new LabelModel(labelRequest.Name, labelRequest.Color, labelRequest.ProjectId));

        return new LabelResponse(label.Id, label.Name, label.Color);
    }

    private ICollection<LabelResponse> Map(ICollection<LabelModel> labels)
    {
        return labels.Select(label => new LabelResponse(label.Id, label.Name, label.Color)).ToList();
    }
}