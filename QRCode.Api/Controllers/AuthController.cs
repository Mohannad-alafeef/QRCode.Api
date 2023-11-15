using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QRCode.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase {
		private readonly ModelContext _context;
		public AuthController(ModelContext context) {
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserAccount userAccount) {
			var user = await _context.UserAccounts.Include(x => x.Role)
				.Where(x => x.Email == userAccount.Email && x.Password == userAccount.Password).SingleOrDefaultAsync();
			if (user != null) {

				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QRCodeSuperSecretKey@345"));
				var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

				var claims = new List<Claim> {
				new Claim("firstName",user.FirstName),
				new Claim("lastName",user.LastName),
				new Claim("email",user.Email),
				new Claim("phone",user.Phone),
				new Claim("imageUrl",user.ImagUrl),
				new Claim("cvUrl",user.CvUrl),
				new Claim("address",user.Address),
				new Claim("dateOfBirth",user.DateOfBirth.ToString(),ClaimValueTypes.Date),
				new Claim("Gender",user.Gender),
				new Claim("roleId",user.Role.Id.ToString(),ClaimValueTypes.Integer64)
				};
				var tokenOptions = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(10), signingCredentials: signingCredential);
				var token = new JwtSecurityTokenHandler();


				var t = token.WriteToken(tokenOptions);

				return Ok(t);
			}
			else {
				return NotFound();
			}


		}
	}
}
