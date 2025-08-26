using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        Task<DocumentDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<DocumentDto>?> GetAddressProofDocumentsAsync(CancellationToken cancellationToken);
        Task<List<DocumentDto>?> GetIdentityProofDocumentsAsync(CancellationToken cancellationToken);
        Task<List<DocumentDto>?> GetAgeProofDocumentsAsync(CancellationToken cancellationToken);
        Task<List<DocumentDto>?> GetQualificationProofDocumentsAsync(CancellationToken cancellationToken);
        Task<List<DocumentDto>?> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string documentName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
