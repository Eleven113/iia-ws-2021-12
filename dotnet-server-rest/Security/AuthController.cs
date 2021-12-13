using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Security;

[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
	[HttpPost("/api/auth")]
	public Object auth([FromBody] UserModel userModel, [FromServices] ITokenService tokenService, [FromServices] IUserRepositoryService userRepositoryService) {
		var user = userRepositoryService.GetUser(userModel);

		if (user == null)
		{
			HttpContext.Response.StatusCode = 401;
			return null;
		}
	
		return new { token = tokenService.BuildToken(user) };
	}
}