using MC.Application.Contracts.Identity;
using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Registration;
using MC.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public AuthController(IAuthService authenticationService, UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            this._authenticationService = authenticationService;
            this._userManager = userManager;
            this._mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _authenticationService.LoginAsync(request, cancellationToken));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _authenticationService.RegisterAsync(request, cancellationToken));
        }
    }
}
