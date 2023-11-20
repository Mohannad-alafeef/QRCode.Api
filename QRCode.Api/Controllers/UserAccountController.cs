using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode.Api.Models;
using QRCode.Api.Services;
using System.ComponentModel.DataAnnotations;

namespace QRCode.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UserAccountController : ControllerBase {
		private readonly IImageHandler _imageHandler;
		private readonly ModelContext _modelContext;

		public UserAccountController(IImageHandler imageHandler, ModelContext modelContext) {
			_imageHandler = imageHandler;
			_modelContext = modelContext;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAll(decimal id) {
			var students = await _modelContext.UserAccounts.Where(x=>x.RoleId == id).ToListAsync();
			return Ok(students);

		}
		[HttpPost]
		public async Task<IActionResult> Create([FromForm, Bind("RoleId,FirstName,LastName,Email,Password,Image,CV,Phone,Gender,Address,DateOfBirth")] UserAccount userAccount) {

			if(!ModelState.IsValid) {
				BadRequest("Missing Data");
			}
			if (userAccount.Image != null) {
				var imageUrl = await _imageHandler.UploadFile(userAccount.Image);
				userAccount.ImagUrl = imageUrl;

			}
			if (userAccount.CV != null) {
				var CvUrl = await _imageHandler.UploadFile(userAccount.CV);
				userAccount.CvUrl = CvUrl;

			}
			await _modelContext.AddAsync(userAccount);
			await _modelContext.SaveChangesAsync();
			return Ok(userAccount);

		}
		[HttpPut("UpdateInfo")]
		public async Task<IActionResult> UpdateInfo([FromForm, Bind("Id,FirstName,LastName,Email,Password,Phone,Gender,Address,DateOfBirth,ImagUrl,CvUrl")] UserAccount userAccount) {

			_modelContext.Update(userAccount);
			await _modelContext.SaveChangesAsync();
			return Ok(userAccount);

		}
		[HttpPut("UpdateCV")]
		public async Task<IActionResult> UpdateCV([FromForm, Bind("Id,CV")] UserAccount userAccount) {
			var user = await _modelContext.UserAccounts.FindAsync(userAccount.Id);
			if (user != null) {
				if (userAccount.CV != null) {
					var cvUrl = await _imageHandler.UploadFile(userAccount.CV);
					user.CvUrl = cvUrl;
					_modelContext.Update(user);
					await _modelContext.SaveChangesAsync();
					return Ok(user);
				}
				else {
					return BadRequest("UnSupported File Type");
				}
			}
			else {
				return NotFound();
			}

		}

		[HttpPut("UpdateImage")]
		public async Task<IActionResult> UpdateImage([FromForm, Bind("Id,Image")] UserAccount userAccount) {
			var user = await _modelContext.UserAccounts.FindAsync(userAccount.Id);
			if (user != null) {
				if (userAccount.Image != null) {
					var imageUrl = await _imageHandler.UploadFile(userAccount.Image);
					user.ImagUrl = imageUrl;
					_modelContext.Update(user);
					await _modelContext.SaveChangesAsync();
					return Ok(user);
				}
				else {
					return BadRequest("UnSupported File Type");
				}
			}
			else {
				return NotFound();
			}

		}
		[HttpGet("UserCourses/{id}")]
		public async Task<IActionResult> UserCourses(decimal id) {
			var user = await _modelContext.UserCourses.Where(x=>x.UserAccountId == id).Include(x=>x.Course).ToListAsync();
			return Ok(user);

		}
        [HttpGet("user/{id}")]
        public async Task<IActionResult> User(decimal id)
        {
            var user = await _modelContext.UserAccounts.FindAsync(id);
            return Ok(user);

        }
    }
}
