using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;

namespace TarefaNinja.API.Controllers;

public class UtilController : BaseController
{
    [HttpGet("unixtime")]
    [AllowAnonymous]
    public IActionResult GetUnixTime()
    {
        return Ok(DateTimeOffset.Now.ToUnixTimeSeconds());
    }
}
