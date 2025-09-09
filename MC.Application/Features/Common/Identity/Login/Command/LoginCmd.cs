using MC.Application.Model.Identity.Authorization;
using MediatR;

namespace MC.Application.Features.Common.Identity.Login.Command
{
    public class LoginCmd : IRequest<AuthResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
