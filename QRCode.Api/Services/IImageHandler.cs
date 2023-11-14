namespace QRCode.Api.Services {
	public interface IImageHandler {

		Task<string> UploadFile(IFormFile file);
	}
}
