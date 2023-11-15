using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase {
		private readonly ModelContext _context;

		public CourseController(ModelContext context) {
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var courses = await _context.Courses.ToListAsync();
			return Ok(courses);

		}
		[HttpGet("ById/{id}")]
		public async Task<IActionResult> GetById(decimal id) {
			var courses = await _context.Courses.FindAsync(id);
			if (courses == null) {
				return NotFound();
			}
			return Ok(courses);

		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("CousreName,StartDate,EndDate,Time,Instructor,Image")]Course course) {
			await _context.AddAsync(course);
			await _context.SaveChangesAsync();

			return Ok(course);

		}
		[HttpPut("Update")]
		public async Task<IActionResult> Update([Bind("Id,CousreName,StartDate,EndDate,Time,Instructor,ImageUrl")]Course course) {
			
			_context.Update(course);
			await _context.SaveChangesAsync();

			return Ok(course);

		}
	}
}
