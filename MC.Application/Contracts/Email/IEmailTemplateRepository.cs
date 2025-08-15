using MC.Application.Contracts.Persistence;
using MC.Application.ModelDto.Common.Email;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Email
{
    public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
    {
        Task<List<EmailTemplateDto>> GetAllEmailTemplatesAsync();
        Task<EmailTemplateDetailDto?> GetEmailTemplateAsync(Guid id);
        Task<EmailTemplateDetailDto?> GetEmailTemplateByEmailTemplateAsync(EmailTemplateType emailTemplateType);
        Task<bool> IsUnique(EmailTemplateType templateName);
        Task<bool> IsUniqueForUpdate(Guid id, EmailTemplateType value);
    }
}
