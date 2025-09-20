using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserDocumentRepository : IGenericRepository<UserDocument>
    {
        Task<PaginatedResponse<UserDocumentDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<UserDocumentDetailDto?> GetUserDocumentByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateUserDocumentAsync(UserDocument request, IFormFile? file, CancellationToken cancellationToken);
        Task<Guid> UpdateUserDocumentAsync(UserDocument request, IFormFile? file, CancellationToken cancellationToken);
    }
}
