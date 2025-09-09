using MC.Application.Contracts.Email;
using MC.Application.Exceptions;
using MC.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Web;

namespace MC.Application.Features.Common.Identity.ForgotPassword.Command
{
   public class ForgotPasswordCmdHandler : IRequestHandler<ForgotPasswordCmd, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderRepository _emailService;
        private readonly IConfiguration _configuration;

        public ForgotPasswordCmdHandler(
            UserManager<ApplicationUser> userManager,
            IEmailSenderRepository emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(ForgotPasswordCmd request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || user.Email == null)
            {
                throw new NotFoundException(nameof(user), request.Email);
            }

            // Generate password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = GenerateForgotPasswordLink(user.Email, token);

            // Send email with reset link
            await _emailService.SendLinkEmailAsync(user.Email, resetLink, Domain.Entity.Enum.EmailTemplateType.ForgotPassword, cancellationToken);

            return Unit.Value;
        }

        private string GenerateForgotPasswordLink(string emailAddress, string token)
        {
            var baseUrl = _configuration["ApplicationConfig:BaseUrl"];
            var encodedEmail = Uri.EscapeDataString(emailAddress);
            var encodedToken = HttpUtility.UrlEncode(token); // Handles URL encoding for the token
            var verificationLink = $"{baseUrl}reset?email={encodedEmail}&token={encodedToken}";
            return verificationLink;
        }

    }
}
