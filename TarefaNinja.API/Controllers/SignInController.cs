using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Utils.Requests;
using TarefaNinja.Utils.Responses;

namespace TarefaNinja.API.Controllers;

public class SignInController : BaseController
{
    private IUserDomain UserDomain { get; }

    public SignInController(IUserDomain userDomain)
    {
        UserDomain = userDomain;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<NewUserResponse>> NewUserAsync([FromBody] NewUserRequest userRequest)
    {
        var user = await UserDomain.CreateNewUserAsync(userRequest);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
