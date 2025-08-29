using MC.Domain.Entity.Common;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Contracts.Persistence.FileHandling.Upload
{
    public interface IFileUploadRepository
    {
        Task<string> UploadProfilePictureAsync(IFormFile file, Guid userProfileId);
        //Task<UploadedDocument> SaveFileAsync(IFormFile file, Guid documentTypeId, Guid userProfileId);
        //Task<UploadedDocument> GetFileAsync(Guid fileId);
        //Task DeleteFileAsync(Guid fileId);
    }
}
