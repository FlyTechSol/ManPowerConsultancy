using AutoMapper;
using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.Helper;
using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Registration;
using MC.Application.Settings;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace MC.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserProfileRepository _userProfileRepository;

        public AuthService(UserManager<ApplicationUser> userManager,
                           RoleManager<ApplicationRole> roleManager,
                           IOptions<JwtSettings> jwtSettings,
                           IEmailSenderRepository emailSenderRepository,
                           IUserProfileRepository userProfileRepository,
                           IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _emailSenderRepository = emailSenderRepository;
            _configuration = configuration;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) throw new UnauthorizedAccessException("Invalid credentials or email.");

            if (await _userManager.IsLockedOutAsync(user))
                throw new UnauthorizedAccessException("Account locked. Try later.");

            var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValid)
            {
                await _userManager.AccessFailedAsync(user);
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            await _userManager.ResetAccessFailedCountAsync(user);

            JwtSecurityToken jwtSecurityToken = await GenerateJwtTokenAsync(user);

            var roles = await _userManager.GetRolesAsync(user); // Fetch user roles

            if (!roles.Any())
            {
                throw new NotFoundException($"User with {request.Email} does not have any role.", request.Email);
            }
            // Fetch role details (names and IDs)
            var roleDetails = new List<RoleDetails>();  // RoleDetails is a custom class containing RoleName and RoleId
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    roleDetails.Add(new RoleDetails
                    {
                        RoleName = role.Name ?? string.Empty,
                        RoleId = role.Id
                    });
                }
            }

            var userProfile = await _userProfileRepository.GetUserProfileByApplicationUserIdAsync(user.Id, cancellationToken);    
            return new AuthResponse
            {
                Id = user.Id,
                FirstName = userProfile != null ? userProfile.FirstName : string.Empty,
                LastName = userProfile != null ? userProfile.LastName : string.Empty,
                MiddleName = userProfile != null ? userProfile.MiddleName : string.Empty,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                RegistrationId = userProfile !=null ? userProfile.RegistrationId : string.Empty,
                Roles = roleDetails,
                //Menus = menus,
                //ProfilePictureUrl = userProfile != null ? userProfile.ProfilePictureUrl : string.Empty,
                IsActive = user.IsActive,
            };
        }
        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var profile = new UserProfile
            {
                FirstName = StringHelper.ToTitleCase(request.FirstName),
                MiddleName = StringHelper.ToTitleCase(request.MiddleName),
                LastName = StringHelper.ToTitleCase(request.LastName),
            };
            var user = new ApplicationUser
            {
                Email = request.Email,
                PhoneNumber = request.Mobile,
                UserName = request.UserName,
                IsActive = true,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                UserProfile = profile,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(request.RoleId))
                    {
                        var roleExists = await _roleManager.RoleExistsAsync("Employee");
                        if (roleExists)
                            await _userManager.AddToRoleAsync(user, "Student");
                        else
                            throw new BadRequestException($"The role 'employee' does not exist.{request.RoleId}");
                    }
                    else
                    {
                        var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                        if (role != null)
                            if (role != null && !string.IsNullOrEmpty(role.Name))
                                await _userManager.AddToRoleAsync(user, role.Name);
                            else
                                throw new BadRequestException($"The role with ID '{request.RoleId}' does not exist or has no name.");
                        else
                            throw new BadRequestException($"The role with ID '{request.RoleId}' does not exist.");
                    }

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var verificationLink = GenerateEmailVerificationLink(user.Id.ToString(), token);

                    var placeholders = new Dictionary<string, string>
                        {
                            { "FirstName", user.UserProfile.FirstName },
                            { "LastName", user.UserProfile.LastName },
                            { "EmailVerificationLink", verificationLink }
                        };

                    var emailSent = await _emailSenderRepository.SendEmailUsingTemplateAsync(user.Email, EmailTemplateType.RegistrationDone, placeholders, cancellationToken);

                    if (!emailSent)
                    {
                        throw new BadRequestException("Registration done but failed to send the welcome email.");
                    }

                    return new RegistrationResponse() { UserId = user.Id };
                }
                catch (Exception ex)
                {
                    throw new BadRequestException($"An error occurred while assigning roles: {ex.Message}");
                }
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }
                throw new BadRequestException($"{str}");
            }
        }
        public async Task<JwtSecurityToken> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim("username", user.UserName ?? string.Empty)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds
            );

            return token;
        }
        public string GenerateEmailVerificationLink(string userId, string token)
        {
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            var encodedToken = HttpUtility.UrlEncode(token);
            var verificationLink = $"{baseUrl}verify-email?userId={userId}&token={encodedToken}";
            return verificationLink;
        }
    }
}
