using MediatR;

namespace MC.Application.Features.Common.Identity.ChangePassword.Command
{
    public class ChangePasswordCmd : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
