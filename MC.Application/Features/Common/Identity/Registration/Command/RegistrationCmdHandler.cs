using MC.Application.Contracts.Identity;
using MC.Application.Exceptions;
using MC.Application.Model.Identity.Registration;
using MediatR;

namespace MC.Application.Features.Common.Identity.Registration.Command
{
    public class RegistrationCmdHandler : IRequestHandler<RegistrationCmd, RegistrationResponse>
    {
        private readonly IAuthService _authenticationService;

        public RegistrationCmdHandler(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegistrationResponse> Handle(RegistrationCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new RegistrationCmdValidator(_authenticationService);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid registration record", validationResult);

            var regRequest = new RegistrationRequest
            {
                Email = request.Email,
                Mobile = request.Mobile,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                RoleId = request.RoleId,
            };
            return await _authenticationService.RegisterAsync(regRequest, cancellationToken);
        }
    }
}
