using MC.Application.Model.Email;
using MC.Domain.Entity.Enum;

namespace MC.Application.Contracts.Email
{
    public interface IEmailSenderRepository
    {
        Task<bool> SendEmail(EmailMessage email, CancellationToken cancellationToken);
        Task<bool> SendResetPasswordEmailAsync(string email, string resetLink, CancellationToken cancellationToken);
        Task<bool> SendEmailUsingTemplateAsync(string recipientEmail, EmailTemplateType templateType, Dictionary<string, string> placeholders, CancellationToken cancellationToken);
    }
}
