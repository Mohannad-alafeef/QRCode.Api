using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UserCourseController : ControllerBase {
		private readonly ModelContext _context;
		public UserCourseController(ModelContext context) {
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Get() {
			var userCourse = await _context.UserCourses.Include(x=>x.Course).ToListAsync();
			
			return Ok(userCourse);
		}
		[HttpGet("ByCourseId/{id}")]
		public async Task<IActionResult> ByCourseId(decimal id) {
			var userCourse = await _context.UserCourses.Where(x=>x.CourseId==id).ToListAsync();
			if (userCourse == null) {
				return NotFound();
			}
			
			return Ok(userCourse);
		}
		[HttpGet("ByUserId/{id}")]
		public async Task<IActionResult> ByUserId(decimal id) {
			var userCourse = await _context.UserCourses.Where(x => x.UserAccountId == id).Include(x=>x.Course).ToListAsync();
			if (userCourse == null) {
				return NotFound();
			}
			
			return Ok(userCourse);
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("CourseId,UserAccountId,Status,Mark")] UserCourse usercourse) {
			await _context.AddAsync(usercourse);
			await _context.SaveChangesAsync();
			return Ok(usercourse);
		}
		[HttpPut("UpdateMark")]
		public async Task<IActionResult> UpdateMark([Bind("Id,Mark")] UserCourse usercourse) {
			var course = await _context.UserCourses.AsNoTracking().Where(x=>x.Id==usercourse.Id).SingleOrDefaultAsync();
			if (course != null) {
				course.Mark = usercourse.Mark;
				 _context.Update(course);
				await _context.SaveChangesAsync();
				return Ok(course);
			}
			else {
				return BadRequest();
			}
		}
		[HttpPut("Update")]
		public async Task<IActionResult> Update([Bind("Id,Mark,Status")] UserCourse usercourse) {
			var course = await _context.UserCourses.AsNoTracking().Where(x=>x.Id==usercourse.Id).SingleOrDefaultAsync();
			if (course != null) {
				course.Mark = usercourse.Mark;
				course.Status = usercourse.Status;
				 _context.Update(course);
				await _context.SaveChangesAsync();
				return Ok(course);
			}
			else {
				return BadRequest();
			}
		}
		[HttpPut("UpdateStatus")]
		public async Task<IActionResult> UpdateStatus([Bind("Id,Status")] UserCourse usercourse) {
			var course = await _context.UserCourses.AsNoTracking().Where(x => x.Id == usercourse.Id).SingleOrDefaultAsync();
			if (course != null) {
				course.Status = usercourse.Status;
				 _context.Update(course);
				await _context.SaveChangesAsync();
				return Ok(course);
			}
			else {
				return BadRequest();
			}
		}

	}
}
