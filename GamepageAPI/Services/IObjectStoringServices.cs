namespace GamepageAPI.Services
{
    public interface IObjectStoringServices
    {
        Task<string> UploadImageAsync(IFormFile photo, string name = null);
    }
}
