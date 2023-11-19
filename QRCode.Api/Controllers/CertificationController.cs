using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;
using QRCode.Api.Services;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CertificationController : ControllerBase {
		private readonly ModelContext _context;
		private readonly IImageHandler _imageHandler;

		public CertificationController(ModelContext context, IImageHandler imageHandler) {
			_context = context;
			_imageHandler = imageHandler;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(decimal id) {
			var certi = await _context.Certificatons.FindAsync(id);
			if (certi == null) {
				return NotFound();
			}
			return Ok(certi);
		}
		[HttpGet("ByUserId/{id}")]
		public async Task<IActionResult> GetByUserId(decimal id) {
			var certi = await _context.Certificatons.Include(x => x.UserCourse).ThenInclude(x => x.Course)
				.Where(x => x.UserCourse.UserAccountId == id).ToListAsync();

			return Ok(certi);
		}
		[HttpGet("ByUserCourseId/{id}")]
		public async Task<IActionResult> GetByUserCourseId(decimal id) {
			var certi = await _context.Certificatons.Where(x=>x.UserCourseId == id).SingleOrDefaultAsync();
			if (certi == null) {
				return NotFound();
			}
			return Ok(certi);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromForm, Bind("UserCourseId,DateOfIssuance,ExpDate,Status,Image")] Certificaton certificaton) {
			if (certificaton.Image != null) {
				var certiUrl = await _imageHandler.UploadFile(certificaton.Image);
				certificaton.CertificatonUrl = certiUrl;
				await _context.AddAsync(certificaton);
				await _context.SaveChangesAsync();
				return Ok(certificaton);

			}
			else {
				return BadRequest("no file");
			}


		}
	}
}
