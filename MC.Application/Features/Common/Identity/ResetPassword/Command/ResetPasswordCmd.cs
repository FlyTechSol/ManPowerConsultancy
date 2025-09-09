using MediatR;

namespace MC.Application.Features.Common.Identity.ResetPassword.Command
{
    public class ResetPasswordCmd : IRequest<Unit>
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
