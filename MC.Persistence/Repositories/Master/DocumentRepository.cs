using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class DocumentRepository : GenericRepository<Domain.Entity.Master.Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<DocumentDto>?> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.Documents
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .Select(response => new DocumentDto
               {
                   Id = response.Id,
                   DocumentName = response.DocumentName,
                   Description = response.Description,
                   IsIdentityProof = response.IsIdentityProof,
                   IsAddressProof = response.IsAddressProof,
                   IsAgeProof = response.IsAgeProof,
                   IsQualificationProof = response.IsQualificationProof
               })
               .ToListAsync(cancellationToken);
        }
        public async Task<List<DocumentDto>?> GetAddressProofDocumentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Documents
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.IsAddressProof)
               .Select(response => new DocumentDto
               {
                   Id = response.Id,
                   DocumentName = response.DocumentName,
                   Description = response.Description,
                   IsIdentityProof = response.IsIdentityProof,
                   IsAddressProof = response.IsAddressProof,
                   IsAgeProof = response.IsAgeProof,
                   IsQualificationProof = response.IsQualificationProof
               })
               .ToListAsync(cancellationToken);
        }
        public async Task<List<DocumentDto>?> GetIdentityProofDocumentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Documents
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.IsIdentityProof)
               .Select(response => new DocumentDto
               {
                   Id = response.Id,
                   DocumentName = response.DocumentName,
                   Description = response.Description,
                   IsIdentityProof = response.IsIdentityProof,
                   IsAddressProof = response.IsAddressProof,
                   IsAgeProof = response.IsAgeProof,
                   IsQualificationProof = response.IsQualificationProof
               })
               .ToListAsync(cancellationToken);
        }
        public async Task<List<DocumentDto>?> GetAgeProofDocumentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Documents
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.IsAgeProof)
               .Select(response => new DocumentDto
               {
                   Id = response.Id,
                   DocumentName = response.DocumentName,
                   Description = response.Description,
                   IsIdentityProof = response.IsIdentityProof,
                   IsAddressProof = response.IsAddressProof,
                   IsAgeProof = response.IsAgeProof,
                   IsQualificationProof = response.IsQualificationProof
               })
               .ToListAsync(cancellationToken);
        }
        public async Task<List<DocumentDto>?> GetQualificationProofDocumentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Documents
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.IsQualificationProof)
               .Select(response => new DocumentDto
               {
                   Id = response.Id,
                   DocumentName = response.DocumentName,
                   Description = response.Description,
                   IsIdentityProof = response.IsIdentityProof,
                   IsAddressProof = response.IsAddressProof,
                   IsAgeProof = response.IsAgeProof,
                   IsQualificationProof = response.IsQualificationProof
               })
               .ToListAsync(cancellationToken);
        }
        public async Task<DocumentDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Documents
                .AsNoTracking()
                .Include(g => g.CreatedByUser)
                .Include(g => g.ModifiedByUser)
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Assets
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Assets
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private DocumentDetailDto MapToDto(Domain.Entity.Master.Document response)
        {
            return new DocumentDetailDto
            {
                Id = response.Id,
                DocumentName = response.DocumentName,
                Description = response.Description,
                IsIdentityProof = response.IsIdentityProof,
                IsAddressProof = response.IsAddressProof,
                IsAgeProof = response.IsAgeProof,
                IsQualificationProof = response.IsQualificationProof,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
        }
    }
}
