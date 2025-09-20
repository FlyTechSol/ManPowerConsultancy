using MC.Application.ModelDto.Registration;

namespace MC.Application.Contracts.Persistence.FileHandling
{
    public interface IFileStorageService
    {
        Task<FileResponseDto> GetFileAsync(string relativePath, CancellationToken cancellationToken);
    }
}
