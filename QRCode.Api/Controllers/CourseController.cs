using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;
using QRCode.Api.Services;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase {
		private readonly ModelContext _context;
		private readonly IImageHandler _imageHandler;

		public CourseController(ModelContext context, IImageHandler imageHandler) {
			_context = context;
			_imageHandler = imageHandler;
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
		public async Task<IActionResult> Create([FromForm, Bind("CourseName,StartDate,EndDate,Time,Instructor,Image")] Course course) {
			if (course.Image != null) {
				var imageUrl = await _imageHandler.UploadFile(course.Image);
				course.ImagUrl = imageUrl;
				await _context.AddAsync(course);
				await _context.SaveChangesAsync();

				return Ok(course);
			}
			else {
				return BadRequest();
			}

		}
		[HttpPut("Update")]
		public async Task<IActionResult> Update([Bind("Id,CourseName,StartDate,EndDate,Time,Instructor,ImageUrl")] Course course) {

			_context.Update(course);
			await _context.SaveChangesAsync();

			return Ok(course);

		}
	}
}
