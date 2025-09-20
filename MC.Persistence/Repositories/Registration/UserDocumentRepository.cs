using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class UserDocumentRepository : GenericRepository<UserDocument>, IUserDocumentRepository
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        public UserDocumentRepository(IFileUploadRepository fileUploadRepository, ApplicationDatabaseContext context) : base(context)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<PaginatedResponse<UserDocumentDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.UserDocuments
                .AsNoTracking()
                .Include(x => x.DocumentType)
                .Where(x => x.UserProfileId == userProfileId && !x.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (!string.IsNullOrWhiteSpace(q.DocumentNumber) && q.DocumentNumber.ToLower().Contains(search)) 
                );
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                //query = query.OrderBy(a => a.IsActive); // default sort
                query = query.OrderByDescending(a => a.DateCreated); 
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<UserDocumentDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<UserDocumentDetailDto?> GetUserDocumentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.UserDocuments
                .AsNoTracking()
                .Include(ba => ba.DocumentType)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<Guid> UpdateUserDocumentAsync(UserDocument request, IFormFile? file, CancellationToken cancellationToken)
        {
            var existing = await _context.UserDocuments
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (existing == null)
                throw new NotFoundException($"User document with Id {request.Id} not found", request.Id);

            existing.DocumentTypeId = request.DocumentTypeId;
            existing.DocumentNumber = request.DocumentNumber;
            existing.IssueDate = request.IssueDate;
            existing.ExpiryDate = request.ExpiryDate;
            existing.IsVerified = request.IsVerified;
            
            if (file != null)
            {
                // (optional) delete old file to avoid orphan files
                if (!string.IsNullOrWhiteSpace(existing.FilePath) &&
                    System.IO.File.Exists(existing.FilePath))
                {
                    System.IO.File.Delete(existing.FilePath);
                }

                var url = await _fileUploadRepository.UploadFileAsync(file, "UserIdentityDoc", false, cancellationToken);
                existing.FilePath = url;
            }
            _context.UserDocuments.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }
        public async Task<Guid> CreateUserDocumentAsync(UserDocument request, IFormFile? file, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                _context.UserDocuments.Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                if (file != null)
                {
                    var url = await _fileUploadRepository
                        .UploadFileAsync(file, "UserIdentityDoc", false, cancellationToken);

                    // update DB with file path
                    request.FilePath = url;
                    _context.UserDocuments.Update(request);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                await transaction.CommitAsync(cancellationToken);
                return request.Id;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
        private UserDocumentDetailDto MapToDto(Domain.Entity.Registration.UserDocument response)
        {
            return new UserDocumentDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                DocumentTypeId = response.DocumentTypeId,
                DocumentType = response.DocumentType.Name,
                FilePath = response.FilePath,
                DocumentNumber = response.DocumentNumber ?? string.Empty,
                IssueDate = response.IssueDate,
                ExpiryDate = response.ExpiryDate,
                IsVerified = response.IsVerified,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
