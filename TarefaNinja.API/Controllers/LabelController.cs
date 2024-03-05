using Microsoft.AspNetCore.Mvc;

using TarefaNinja.Domain;
using TarefaNinja.Utils.Requests;

namespace TarefaNinja.API.Controllers;

public class LabelController : ControllerBase
{
    public LabelController(ILabelDomain labelDomain)
    {
        LabelDomain = labelDomain;
    }

    private ILabelDomain LabelDomain { get; }

    [HttpPost]
    public async Task<ActionResult<LabelResponse>> PostAsync([FromBody] NewLabelRequest labelRequest)
    {
        var label = await LabelDomain.InsertAsync(labelRequest);

        return Ok(label);
    }
}
