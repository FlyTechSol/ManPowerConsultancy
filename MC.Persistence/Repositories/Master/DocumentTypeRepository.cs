using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Enum.Common;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class DocumentTypeRepository : GenericRepository<Domain.Entity.Master.DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<DocumentTypeDto>?> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.DocumentTypes
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .Select(response => new DocumentTypeDto
               {
                   Id = response.Id,
                   Name = response.Name,
                   Description = response.Description,
                   Purpose = response.Purpose
               })
               .ToListAsync(cancellationToken);
        }
      
        public async Task<DocumentTypeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.DocumentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<List<DocumentTypeDto>> GetDocumentsByPurposeAsync(DocumentPurpose purpose, CancellationToken cancellationToken)
        {
            return await _context.DocumentTypes
                .Where(d => (d.Purpose & purpose) == purpose) // matches any document with this purpose flag
                .Select(d => new DocumentTypeDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Purpose = d.Purpose,
                    Description = d.Description
                })
                .ToListAsync(cancellationToken);
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
        private DocumentTypeDetailDto MapToDto(Domain.Entity.Master.DocumentType response)
        {
            return new DocumentTypeDetailDto
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                Purpose = response.Purpose,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
