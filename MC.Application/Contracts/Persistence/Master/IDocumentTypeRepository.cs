using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Enum.Common;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IDocumentTypeRepository : IGenericRepository<DocumentType>
    {
        Task<DocumentTypeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<DocumentTypeDto>> GetDocumentsByPurposeAsync(DocumentPurpose purpose, CancellationToken cancellationToken);
        Task<List<DocumentTypeDto>?> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string documentName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
