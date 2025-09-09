using MediatR;

namespace MC.Application.Features.Common.Identity.ForgotPassword.Command
{
    public class ForgotPasswordCmd : IRequest<Unit>
    {
        public string Email { get; set; } = string.Empty;
    }
}
