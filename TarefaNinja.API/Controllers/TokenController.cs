using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TarefaNinja.API.Abstracts;
using TarefaNinja.Domain;
using TarefaNinja.Domain.Requests;
using TarefaNinja.Domain.Responses;
using TarefaNinja.Services;

namespace TarefaNinja.API.Controllers;

public class TokenController : BaseController
{
    private ITokenService TokenService { get; }

    private IUserDomain UserDomain { get; }

    private IConfiguration Configuration { get; }

    public TokenController(ITokenService tokenService, IUserDomain userDomain, IConfiguration configuration)
    {
        TokenService = tokenService;
        UserDomain = userDomain;
        Configuration = configuration;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<NewTokenResponse>> PostNewTokenAsync([FromBody] NewTokenRequest request)
    {
        var user = await UserDomain.LoginAsync(request.Login, request.Password);

        if (user is null)
        {
            return NotFound();
        }

        var jwtKey = Configuration["Jwt:Key"];
        var jwtIssuer = Configuration["Jwt:Issuer"];
        var jwtAudience = Configuration["Jwt:Audience"];

        ArgumentNullException.ThrowIfNull(jwtKey);
        ArgumentNullException.ThrowIfNull(jwtIssuer);
        ArgumentNullException.ThrowIfNull(jwtAudience);

        var token = TokenService.GenerateJwtToken(user.Login, user.Name, user.userId, user.Email, jwtKey, jwtIssuer, jwtAudience);

        return Ok(new NewTokenResponse(token));
    }
}
