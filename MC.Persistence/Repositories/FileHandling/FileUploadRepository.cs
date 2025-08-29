using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp;

namespace MC.Persistence.Repositories.FileHandling
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileUploadRepository(ApplicationDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<string> UploadProfilePictureAsync(IFormFile file, Guid userProfileId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty", nameof(file));

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            if (file.Length > 10 * 1024 * 1024) // 10 MB limit
                throw new ArgumentException("File size exceeds 10 MB");

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Resize image if it's an image (optional)
            if (file.ContentType.StartsWith("image/"))
            {
                ResizeImage(filePath, 100); // Resize to approx 100KB (implement this yourself)
            }

            // Save relative URL/path to UserProfile
            var userProfile = await _context.UserProfiles.FindAsync(userProfileId);

            if (userProfile == null)
                throw new InvalidOperationException("User profile not found");

            // Store relative path so you can serve it as URL later
            userProfile.ProfilePictureUrl = Path.Combine("uploads", uniqueFileName).Replace("\\", "/");

            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();

            return userProfile.ProfilePictureUrl; // Return the URL/path for client use
        }

        private void ResizeImage(string filePath, int targetSizeKb)
        {
            using var stream = File.OpenRead(filePath);

            // Load image using SixLabors.ImageSharp
            using var image = Image.Load(stream);

            int quality = 75;
            byte[] imageBytes;

            do
            {
                using var ms = new MemoryStream();
                var encoder = new JpegEncoder
                {
                    Quality = quality
                };

                image.Save(ms, encoder);
                imageBytes = ms.ToArray();

                quality -= 5;

            } while (imageBytes.Length / 1024 > targetSizeKb && quality > 10);

            // Overwrite the file with compressed bytes
            File.WriteAllBytes(filePath, imageBytes);
        }

    }
}
