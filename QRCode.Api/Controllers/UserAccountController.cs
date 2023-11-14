using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCode.Api.Models;
using QRCode.Api.Services;

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

		[HttpPost]
		public async Task<IActionResult> Create([FromForm, Bind("RoleId,Firstname,Lastname,Email,Password,Image,CV,Phone,Gender,Address,Dateofbirth")] UserAccount userAccount) {

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
		//[HttpPost("UpdateCV")]
		//public async Task<IActionResult> UpdateCV([FromForm,Bind("Id,CV")] UserAccount userAccount) {
		//	var user 
		//	if (userAccount.CV != null) {

		//	}

		//}
	}
}
