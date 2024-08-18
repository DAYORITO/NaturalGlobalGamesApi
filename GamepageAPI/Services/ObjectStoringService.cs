using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using dotenv.net;

namespace GamepageAPI.Services
{
    public class ObjectStoringService: IObjectStoringServices

    {

        private Account account;
        private readonly Cloudinary cloudinary;

        public ObjectStoringService() {

            //cloudinaryUrl = "cloudinary://986568654868493:Mr2_AWW7avD6oeCxvn2buwi_JI8@dz6oripah;";
            account = new Account(
            "dz6oripah",
            "986568654868493",
            "Mr2_AWW7avD6oeCxvn2buwi_JI8"
            );
            cloudinary = new Cloudinary(account);
        }
        public async Task<string> UploadImageAsync(IFormFile photo, string name = null)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name != null ? name+"image": photo.FileName, photo.OpenReadStream()),
                Overwrite = true,
                Folder = "GameImages"
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
