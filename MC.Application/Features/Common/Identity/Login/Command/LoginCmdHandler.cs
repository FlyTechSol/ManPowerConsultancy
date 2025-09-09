using MC.Application.Contracts.Identity;
using MC.Application.Features.Common.Identity.ChangePassword.Command;
using MC.Application.Model.Identity.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Common.Identity.Login.Command
{
    public class LoginCmdHandler : IRequestHandler<LoginCmd, AuthResponse>
    {
        private readonly IAuthService _authenticationService;

        public LoginCmdHandler(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthResponse> Handle(LoginCmd request, CancellationToken cancellationToken)
        {
            var authRequest = new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            };

            return await _authenticationService.LoginAsync(authRequest, cancellationToken);
        }
    }
}
