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
}
