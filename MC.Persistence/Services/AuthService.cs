using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Navigation;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.Helper;
using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Application.Settings;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Enum.Registration;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Linq.Dynamic.Core;

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
        private readonly INavigationNodeRepository _menuService;
        private readonly ApplicationDatabaseContext _context;
        public AuthService(UserManager<ApplicationUser> userManager,
                           RoleManager<ApplicationRole> roleManager,
                           IOptions<JwtSettings> jwtSettings,
                           IEmailSenderRepository emailSenderRepository,
                           IUserProfileRepository userProfileRepository,
                           INavigationNodeRepository menuService,
                           IConfiguration configuration,
                           ApplicationDatabaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _emailSenderRepository = emailSenderRepository;
            _configuration = configuration;
            _userProfileRepository = userProfileRepository;
            _menuService = menuService;
            _context = context;
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
                // Increase failed attempts
                await _userManager.AccessFailedAsync(user);
                // Check if lockout should now apply
                if (await _userManager.IsLockedOutAsync(user))
                {
                    throw new UnauthorizedAccessException("Account locked due to multiple failed login attempts. Try again later.");
                }
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
            if (!user.IsActive)  // Or user.IsActive == false based on your implementation
            {
                throw new UnauthorizedAccessException("This user is no longer active.");
            }
            // Check if the user's email is confirmed
            if (!user.EmailConfirmed)
            {
                throw new BadRequestException($"Email for '{request.Email}' is not verified. Kindly verifiy the email before login. Make sure verification link is active for 24 hrs only.");
            }
            await _userManager.ResetAccessFailedCountAsync(user);

            JwtSecurityToken jwtSecurityToken = await GenerateJwtTokenAsync(user);

            var roles = await _userManager.GetRolesAsync(user); // Fetch user roles

            if (!roles.Any())
                throw new NotFoundException($"User with {request.Email} does not have any role.", request.Email);

            var roleDetails = new List<RoleDetails>();
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

            //Fetch 2 level menus based on roles
            //var menus = await _menuService.GetMenusForRolesAsync(roles.ToList(), cancellationToken);

            //fetch multilevel menus
            var menus = await _menuService.GetNavigationsForRolesAsync(roles.ToList(), cancellationToken);

            return new AuthResponse
            {
                Id = user.Id,
                FirstName = userProfile != null ? userProfile.FirstName : string.Empty,
                LastName = userProfile != null ? userProfile.LastName : string.Empty,
                MiddleName = userProfile != null ? userProfile.MiddleName : string.Empty,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                RegistrationId = userProfile != null ? userProfile.RegistrationId : string.Empty,
                Roles = roleDetails,
                CompanyName = userProfile != null ? userProfile.CompanyName ?? string.Empty : string.Empty,
                ProfilePictureUrl = userProfile != null ? userProfile.ProfilePictureUrl ?? string.Empty : string.Empty,
                IsActive = user.IsActive,
                Menus = menus,
            };
        }
        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                PhoneNumber = request.Mobile,
                UserName = request.UserName,
                IsActive = true,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var str = new StringBuilder();
                foreach (var err in result.Errors)
                    str.AppendLine($"• {err.Description}");
                throw new BadRequestException(str.ToString());
            }

            try
            {
                // create profile separately
                var profile = new UserProfile
                {
                    FirstName = StringHelper.ToTitleCase(request.FirstName),
                    MiddleName = StringHelper.ToTitleCase(request.MiddleName),
                    LastName = StringHelper.ToTitleCase(request.LastName),
                    Email = request.Email,
                    MobileNumber = request.Mobile,
                    IsActive = true,
                    UserProfileStatus = Domain.Entity.Enum.Registration.UserProfileStatus.Draft,
                    CompanyId = request.CompanyId,
                    UserId = user.Id // very important
                };

                await _userProfileRepository.CreateUserProfileAsync(profile, user.Id, null, cancellationToken);
                //await _userProfileRepository.SaveChangesAsync();

                // assign role
                var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                if (role == null || string.IsNullOrEmpty(role.Name))
                    throw new BadRequestException($"The role with ID '{request.RoleId}' does not exist or has no name.");

                await _userManager.AddToRoleAsync(user, role.Name);

                // email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var verificationLink = GenerateEmailVerificationLink(user.Id.ToString(), token);

                var placeholders = new Dictionary<string, string>
                    {
                        { "FirstName", profile.FirstName }, // use profile directly
                        { "LastName", profile.LastName },
                        { "EmailVerificationLink", verificationLink }
                    };

                var emailSent = await _emailSenderRepository
                    .SendEmailUsingTemplateAsync(user.Email, EmailTemplateType.RegistrationDone, placeholders, cancellationToken);

                if (!emailSent)
                    throw new BadRequestException("Registration done but failed to send the welcome email.");

                return new RegistrationResponse { UserId = user.Id };
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"An error occurred while assigning roles: {ex.Message}");
            }
        }

        public async Task<PaginatedResponse<RegsiteredApprovedUserDto>> GetAllRegisteredApprovedUsersAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApplicationUsers
                .AsNoTracking()
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up.Company)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up.Salutation)
                .Where(u =>
                    u.UserProfile != null &&
                    u.UserProfile.UserProfileStatus == UserProfileStatus.Approved &&
                    u.UserProfile.IsActive); // adjust to your "approved" definition

            // Search
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (q.UserProfile != null && q.UserProfile.FirstName != null && q.UserProfile.FirstName.ToLower().Contains(search)) ||
                    (q.UserProfile != null && q.UserProfile.LastName != null && q.UserProfile.LastName.ToLower().Contains(search)) ||
                    (q.UserName != null && q.UserName.ToLower().Contains(search))
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                if (queryParams.Column == "DateCreated")
                {
                    queryParams.Column = "UserName";
                }
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";
                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(u => u.UserProfile.FirstName); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<RegsiteredApprovedUserDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<JwtSecurityToken> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Standard JWT "subject"
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),   // ASP.NET standard
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                    new Claim("username", user.UserName ?? string.Empty),
                    new Claim("uid", user.Id.ToString())
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
        public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }
        public async Task<bool> IsUserNameUnique(string userName, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user == null;
        }

        private RegsiteredApprovedUserDto MapToDto(ApplicationUser u)
        {
            return new RegsiteredApprovedUserDto
            {
                Id = u.Id,
                TitleId = u.UserProfile?.TitleId,
                Title = u.UserProfile?.Salutation?.Name,
                FirstName = u.UserProfile?.FirstName ?? string.Empty,
                MiddleName = u.UserProfile?.MiddleName ?? string.Empty,
                LastName = u.UserProfile?.LastName ?? string.Empty,
                FullName = $"{u.UserProfile?.FirstName} {u.UserProfile?.LastName}".Trim() + " (" + u.UserProfile?.Designation?.Name + ")",
                EmailAddress = u.UserProfile?.Email ?? string.Empty,
                PhoneNumber = u.UserProfile?.MobileNumber ?? string.Empty,
                UserName = u.UserName ?? string.Empty,
                DesignationId = u.UserProfile?.DesignationId,
                Designation = u.UserProfile?.Designation?.Name,
                CompanyId = u.UserProfile?.CompanyId,
                Company = u.UserProfile?.Company?.CompanyName
            };
        }

    }
}
