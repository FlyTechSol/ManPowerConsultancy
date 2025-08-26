using MC.Application.Contracts.Email;
using MC.Application.ModelDto.Common.Email;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Enum;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace MC.Persistence.Repositories.Common
{
    public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<EmailTemplateDto>> GetAllEmailTemplatesAsync()
        {
            return await _context.EmailTemplates
                .AsNoTracking()
                .Where(q => !q.IsDeleted)
                .Select(q => new EmailTemplateDto
                {
                    Id = q.Id,
                    TemplateName = q.TemplateName.ToString(),
                    Subject = q.Subject,
                    Body = q.Body,
                })
                .ToListAsync();
        }

        public async Task<EmailTemplateDetailDto?> GetEmailTemplateAsync(Guid id)
        {
            var response = await _context.EmailTemplates
                .Include(q => q.CreatedByUser)
                    .ThenInclude(user => user.UserProfile)
                .Include(q => q.ModifiedByUser)
                    .ThenInclude(user => user.UserProfile)
                 .Where(q => !q.IsDeleted)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (response == null)
            {
                return null;
            }

            var dto = new EmailTemplateDetailDto
            {
                Id = response.Id,
                TemplateName = response.TemplateName.ToString(),
                Subject = response.Subject,
                Body = response.Body,
                //DateCreated = response.DateCreated.HasValue
                //    ? response.DateCreated.Value.ToString("dd-MM-yyyy HH:mm:ss")
                //    : string.Empty,
                //DateModified = response.DateModified.HasValue
                //    ? response.DateModified.Value.ToString("dd-MM-yyyy HH:mm:ss")
                //    : string.Empty,
                //CreatedByName = response.CreatedByUser != null
                //    ? $"{response.CreatedByUser.FirstName} {response.CreatedByUser.LastName}"
                //    : string.Empty,
                //ModifiedByName = response.ModifiedByUser != null
                //    ? $"{response.ModifiedByUser.FirstName} {response.ModifiedByUser.LastName}"
                //    : string.Empty
            };

            return dto;
        }
        public async Task<EmailTemplateDetailDto?> GetEmailTemplateByEmailTemplateAsync(EmailTemplateType emailTemplateType)
        {
           var response = await _context.EmailTemplates
                .Where(q => !q.IsDeleted)
                .FirstOrDefaultAsync(q => q.TemplateName == emailTemplateType);

            if (response == null)
            {
                return null;
            }

            var dto = new EmailTemplateDetailDto
            {
                Id = response.Id,
                TemplateName = response.TemplateName.ToString(),
                Subject = response.Subject,
                Body = response.Body,
            };

            return dto;

        }

        public async Task<bool> IsUnique(EmailTemplateType templateName)
        {
            return !await _context.EmailTemplates
               .Where(q => q.TemplateName == templateName && !q.IsDeleted)  // Exclude deleted records
               .AnyAsync();
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, EmailTemplateType value)
        {
            // but exclude the current record by Id and records that are marked as deleted.
            return !await _context.EmailTemplates
                .Where(q => q.TemplateName == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
    }
}
