using MC.Application.Contracts.Persistence;
using MC.Application.ModelDto.Common.Email;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Enum;

namespace MC.Application.Contracts.Email
{
    public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
    {
        Task<PaginatedResponse<EmailTemplateDetailDto>?> GetAllEmailTemplatesAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<EmailTemplateDetailDto?> GetEmailTemplateAsync(Guid id, CancellationToken cancellationToken);
        Task<EmailTemplateDetailDto?> GetEmailTemplateByEmailTemplateAsync(EmailTemplateType emailTemplateType, CancellationToken cancellationToken);
        Task<bool> IsUnique(EmailTemplateType templateName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, EmailTemplateType value, CancellationToken cancellationToken);
    }
}
