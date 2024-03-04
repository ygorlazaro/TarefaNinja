using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TarefaNinja.API.Abstracts;

[Route("[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
}
