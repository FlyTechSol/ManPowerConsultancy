using MC.Application.Contracts.Email;
using MC.Application.ModelDto.Common.Email;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Enum;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Common
{
    public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<EmailTemplateDetailDto>?> GetAllEmailTemplatesAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.EmailTemplates
                .AsNoTracking()
                .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.TemplateName.ToString().ToLower().Contains(search) ||
                    q.Subject.ToLower().Contains(search)
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
                query = query.OrderBy(a => a.TemplateName.ToString()); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<EmailTemplateDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<EmailTemplateDetailDto?> GetEmailTemplateAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.EmailTemplates
                .Where(e => !e.IsDeleted && e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<EmailTemplateDetailDto?> GetEmailTemplateByEmailTemplateAsync(EmailTemplateType emailTemplateType, CancellationToken cancellationToken)
        {
            var response = await _context.EmailTemplates
                 .Where(q => !q.IsDeleted && q.TemplateName == emailTemplateType)
                 .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(EmailTemplateType templateName, CancellationToken cancellationToken)
        {
            return !await _context.EmailTemplates
               .Where(q => q.TemplateName == templateName && !q.IsDeleted)  // Exclude deleted records
               .AnyAsync(cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, EmailTemplateType value, CancellationToken cancellationToken)
        {
            // but exclude the current record by Id and records that are marked as deleted.
            return !await _context.EmailTemplates
                .Where(q => q.TemplateName == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync(cancellationToken);
        }
        private EmailTemplateDetailDto MapToDto(EmailTemplate response)
        {
            return new EmailTemplateDetailDto
            {
                Id = response.Id,
                TemplateName = response.TemplateName.ToString(),
                Subject = response.Subject,
                Body = response.Body,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
