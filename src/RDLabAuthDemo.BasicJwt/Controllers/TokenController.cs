using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RDLabAuthDemo.BasicJwt.Config;

namespace RDLabAuthDemo.BasicJwt.Controllers
{
	[ApiController]
	[Route("token")]
	public class TokenController : ControllerBase
	{
		private readonly IOptions<JwtTokenOptions> _options;

		public TokenController(IOptions<JwtTokenOptions> options)
		{
			_options = options;
		}

		[HttpGet]
		public ActionResult<string> Token(string userName, string password)
		{
			if (string.Equals(userName, "artem")
			    && string.Equals(password, "securePassword") )
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
				var token = new JwtSecurityToken(
					_options.Value.Issuer,
					_options.Value.Audience,
					new Claim[]
					{
						new(JwtRegisteredClaimNames.Iss, _options.Value.Issuer),
						new(JwtRegisteredClaimNames.Email, "some.email@mail.com")
					},
					DateTime.UtcNow,
					DateTime.UtcNow.AddHours(1),
					credentials);
				return Ok(new {access_token = new JwtSecurityTokenHandler().WriteToken(token)});
			}

			return Challenge();
		}
	}
}