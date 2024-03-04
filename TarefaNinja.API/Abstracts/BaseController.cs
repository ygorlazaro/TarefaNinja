using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TarefaNinja.API.Abstracts;

[Route("[controller]")]
[ApiController]
[Authorize]
[ApiVersion(1)]
public class BaseController : ControllerBase
{
    protected Guid GetUserId()
    {
        var claim = User.Claims.FirstOrDefault(c => c.Type.Equals("Id", StringComparison.Ordinal)) ?? throw new BadHttpRequestException("Usuário sem permissão");

        return Guid.Parse(claim.Value);
    }

    protected bool IsAuthenticated()
    {
        return User.Claims.Any();
    }
}
