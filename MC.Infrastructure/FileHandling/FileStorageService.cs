using MC.Application.Contracts.Persistence.Common;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;

namespace MC.Infrastructure.FileHandling
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IAppEnvironment _env;

        public FileStorageService(IAppEnvironment env)
        {
            _env = env;
        }

        public async Task<FileResponseDto> GetFileAsync(string relativePath, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine(_env.WebRootPath, relativePath);

            if (!File.Exists(filePath))
                throw new NotFoundException("Passbook file not found on server", "Passbook file path");

            var contentType = GetContentType(filePath);
            var fileName = Path.GetFileName(filePath);
            var fileBytes = await File.ReadAllBytesAsync(filePath, cancellationToken);

            return new FileResponseDto
            {
                FileBytes = fileBytes,
                ContentType = contentType,
                FileName = fileName
            };
        }

        private static string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".pdf" => "application/pdf",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "application/octet-stream"
            };
        }
    }

}
