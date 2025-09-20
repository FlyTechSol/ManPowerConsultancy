using MC.Application.Contracts.Identity;
using MC.Application.Features.Common.Identity.ChangePassword.Command;
using MC.Application.Features.Common.Identity.ForgotPassword.Command;
using MC.Application.Features.Common.Identity.GetRegsiteredUser.Query;
using MC.Application.Features.Common.Identity.Login.Command;
using MC.Application.Features.Common.Identity.Registration.Command;
using MC.Application.Features.Common.Identity.ResetPassword.Command;
using MC.Application.Features.Common.Identity.UnlockAccount.Command;
using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Identity;
using MC.Application.Model.Identity.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MC.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserContext _userContext;
        private readonly IIdentityService _identityService;
        public AuthController(IMediator mediator, IIdentityService identityService, IUserContext userContext)
        {
            this._mediator = mediator;
            _identityService = identityService;
            _userContext = userContext;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("approved")]
        public async Task<ActionResult<ApiResponse<PaginatedResponse<RegsiteredApprovedUserDto>>>> GetAll([FromQuery] QueryParams queryParams, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllRegisteredApprovedUsersQuery(queryParams), cancellationToken);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCmd
            {
                Email = request.Email,
                Password = request.Password
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result); // result is AuthResponse
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request, CancellationToken cancellationToken)
        {
            var command = new RegistrationCmd
            {
                Email = request.Email,
                Mobile = request.Mobile,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                RoleId = request.RoleId,
                CompanyId = request.CompanyId,
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok("Registration completed successfully. Please check your email to activate your account.");
        }

        [Authorize] // optional, depending on your requirements
        [HttpPost("unlock")]
        public async Task<IActionResult> UnlockAccount([FromBody] UnlockAccountRequest request)
        {
            var command = new UnlockAccountCmd
            {
                Email = request.Email
            };

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { Message = $"Account for '{request.Email}' has been unlocked." });
            }

            return BadRequest(new { Message = $"Account for '{request.Email}' could not be unlocked." });
        }


        [HttpPost("forgot-password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCmd request)
        {
            await _mediator.Send(request);
            return Ok("Password reset link has been sent to your email.");
        }

        [HttpGet("verify-email")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("User Id and token are required.");
            }

            if (!Guid.TryParse(userId, out var userGuid))
            {
                return BadRequest("Invalid User Id format.");
            }

            var user = await _identityService.GetUserByIdAsync(userGuid);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            // Decode the token
            //var decodedToken = WebUtility.UrlDecode(token);
            //Console.WriteLine($"Received Token (encoded): {token}");
            //var decodedToken = HttpUtility.UrlDecode(token);
            //Console.WriteLine($"Decoded Token: {decodedToken}");
            var decodedToken = HttpUtility.UrlDecode(token).Replace(' ', '+');

            var result = await _identityService.ConfirmEmailAsync(userGuid, decodedToken);
            if (result)
            {
                return Ok("Email verified successfully. Kindly login to website and complete your profile.");
            }
            else
            {
                return BadRequest("Invalid or expired token.");
            }
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCmd request)
        {
            await _mediator.Send(request);
            return Ok("Password has been reset successfully.");
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return BadRequest("New password and confirmation do not match.");
            }
            var userId = _userContext.UserGuidId;
            if (userId == Guid.Empty)
                throw new UnauthorizedAccessException("User not found.");

            var command = new ChangePasswordCmd
            {
                UserId = userId,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword
            };

            var result = await _mediator.Send(command);
            if (!result)
            {
                return BadRequest("Failed to change password. Please verify your current password.");
            }
            return Ok("Password successfully changed.");
        }
    }
}
