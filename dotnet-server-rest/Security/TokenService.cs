using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Security;

public class TokenService : ITokenService
{
	private TimeSpan ExpiryDuration = new TimeSpan(0, 30, 0);
	private byte[] _key = null;
	private string _issuer = null;

	public TokenService(IConfiguration configuration) {
		this._key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
		this._issuer = configuration["Jwt:Issuer"];
	}

	public string BuildToken(UserModel user)
	{
		var claims = new[]
		{
			new Claim(ClaimTypes.Name, user.Username),
			new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
		};
 
		var securityKey = new SymmetricSecurityKey(this._key);
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
		var tokenDescriptor = new JwtSecurityToken(
			this._issuer,
			this._issuer,
			claims,
			expires: DateTime.Now.Add(ExpiryDuration),
			signingCredentials: credentials
		);
		
		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
	}
}