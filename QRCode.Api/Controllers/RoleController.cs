using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase {
		private readonly ModelContext _context;

		public RoleController(ModelContext context) {
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get() {
			var role = await _context.UserAccounts.Where(x => x.Role.RoleName == "User").ToListAsync();
			return Ok(role);

		}
		
	}
}
