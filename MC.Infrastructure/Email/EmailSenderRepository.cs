using MC.Application.Contracts.Email;
using MC.Application.Model.Email;
using MC.Application.Settings;
using MC.Domain.Entity.Enum;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;


namespace MC.Infrastructure.Email
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly EmailSettings _emailSettings;
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public EmailSenderRepository(IOptions<EmailSettings> emailSettings, IEmailTemplateRepository emailTemplateRepository)
        {
            _emailSettings = emailSettings.Value;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            // Send email via SMTP
            return await SendEmailViaSmtp(email);
        }

        public async Task<bool> SendEmailUsingTemplateAsync(string recipientEmail, EmailTemplateType templateType, Dictionary<string, string> placeholders)
        {
            var template = await _emailTemplateRepository.GetEmailTemplateByEmailTemplateAsync(templateType);

            if(template==null)
                return false; 
            // Replace placeholders in the template body
            var body = template.Body;
            var subject = template.Subject;

            foreach (var placeholder in placeholders)
            {
                body = body.Replace($"{{{placeholder.Key}}}", placeholder.Value);
                subject = subject.Replace($"{{{placeholder.Key}}}", placeholder.Value);
            }

            var emailMessage = new EmailMessage
            {
                To = recipientEmail,
                Subject = subject,
                Body = body
            };              

            return await SendEmail(emailMessage);
        }

        public async Task<bool> SendResetPasswordEmailAsync(string email, string resetLink)
        {
            var template = await _emailTemplateRepository.GetEmailTemplateByEmailTemplateAsync(EmailTemplateType.ForgotPassword);

            var body = template.Body.Replace("{ResetLink}", resetLink); // Match the placeholder in your template
            var subject = template.Subject;

            var emailMessage = new EmailMessage
            {
                To = email,
                Subject = subject,
                Body = body
            };

            return await SendEmail(emailMessage);
        }
        private async Task<bool> SendEmailViaSmtp(EmailMessage email)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.FromAddress, _emailSettings.FromName),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email.To);

            using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
                catch (Exception ex)
                {
                    // Log exception here (e.g., using a logging framework)
                    return false;
                }
            }
        }
    }
}
