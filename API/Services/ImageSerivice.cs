// using CloudinaryDotNet;
// using CloudinaryDotNet.Actions;
// using Microsoft.Extensions.Options;

// namespace API.Services;

// public class ImageSerivice
// {
//   private readonly Cloudinary _cloudinary;

//   public ImageSerivice(IOptions<CloudinarySetting> config)
//   {
//     var acc = new Account(
//       config.Value.CloudName,
//       config.Value.ApiKey,
//       config.Value.ApiSecret
//     );
//     _cloudinary = new Cloudinary(acc);
//   }

//   public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
//   {
//     var imageUploadResult = new ImageUploadResult();
//     if (file.Length > 0)
//     {
//       using var stream = file.OpenReadStream();

//       var uploadParams = new ImageUploadParams
//       {
//         File = new FileDescription(file.FileName, stream),
//         Folder = "rs-mentorApp"
//       };
//       imageUploadResult = await _cloudinary.UploadAsync(uploadParams);
//     }
//     return imageUploadResult;
//   }

//   public async Task<DeletionResult> DeleteImageAsync(string publicId)
//   {
//     var deletParams = new DeletionParams(publicId);

//     var result = await _cloudinary.DestroyAsync(deletParams);

//     return result;
//   }
// }
