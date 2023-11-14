
using Imagekit.Sdk;
using QRCode.Api.Models;

namespace QRCode.Api.Services {
	public class ImageHandler : IImageHandler {
		ImagekitClient imagekit;

		public ImageHandler() {
			imagekit = new ImagekitClient("public_uDdCe0rO2uspx+x9wNSJ7kpkjRc=", "private_8b6XZ1OkBmStn0vFbYWzWVbvAMg=", "https://ik.imagekit.io/m1dw7xcao");
		}

		public async Task<string> UploadFile(IFormFile file) {
			byte[] buffer;
			using (MemoryStream ms = new MemoryStream()) {
				await file.CopyToAsync(ms);
				buffer = ms.ToArray();

			}
			var fName = Guid.NewGuid().ToString();
			FileCreateRequest ob = new FileCreateRequest {
				file = buffer,
				fileName = fName
			};
			var result = await imagekit.UploadAsync(ob);
			return result.url;
		}
	}
}
