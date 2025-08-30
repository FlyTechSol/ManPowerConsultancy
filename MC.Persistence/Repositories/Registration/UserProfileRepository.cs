using MC.Application.Contracts.Email;
using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IRegistrationIdGeneratorRepository _registrationIdGeneratorRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        public UserProfileRepository(
            IEmailSenderRepository emailSenderRepository,
            IRegistrationIdGeneratorRepository registrationIdGeneratorRepository,
            IFileUploadRepository fileUploadRepository,
            ApplicationDatabaseContext context) : base(context)
        {
            _emailSenderRepository = emailSenderRepository;
            _registrationIdGeneratorRepository = registrationIdGeneratorRepository;
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<UserProfileDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _context.UserProfiles
                .AsNoTracking()
                .Include(x => x.Company)
                .Include(x => x.RecruitmentType)
                .Include(x => x.Salutation)
                .Include(x => x.Gender)
                .Where(up => up.RegistrationId == registrationId && !up.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<UserProfileDto?> GetUserProfileByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.UserProfiles
                .AsNoTracking()
                .Include(x => x.Company)
                .Include(x => x.RecruitmentType)
                .Include(x => x.Salutation)
                .Include(x => x.Gender)
                .Where(up => up.Id == id && !up.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<UserProfileShortDto?> GetUserProfileByApplicationUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.UserProfiles
                .AsNoTracking()
                .Where(up => up.UserId == userId && !up.IsDeleted)
                .Select(up => new UserProfileShortDto
                {
                    Id = up.Id,
                    RegistrationId = up.RegistrationId,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Email = up.Email,
                    MobileNumber = up.MobileNumber,
                    RoleName = "",
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<Guid> CreateUserProfileAsync(UserProfileDto request, CancellationToken cancellationToken)
        {
            var RegId = await _registrationIdGeneratorRepository.GetNextRegistrationIdAsync(request.CompanyId);

            var userProfile = new UserProfile
            {
                RegistrationId = RegId,
                TitleId = request.TitleId,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                RecruitmentTypeId = request.RecruitmentTypeId,
                AadhaarNumber = request.AadhaarNumber,
                PanNumber = request.PanNumber,
                UanNumber = request.UanNumber,
                EsicNumber = request.EsicNumber,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                AlternatePhoneNumber = request.AlternatePhoneNumber,
                DateOfRegistration = request.DateOfRegistration ?? DateTime.UtcNow,
                DateOfBirth = request.DateOfBirth,
                PlaceOfBirth = request.PlaceOfBirth,
                DateOfJoining = request.DateOfJoining ?? DateTime.UtcNow.Date,
                GenderId = request.GenderId,
                IdentityMarks = request.IdentityMarks,
                IsActive = true
            };
            // Save to database
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            // Send email
            if (!string.IsNullOrWhiteSpace(userProfile.Email))
            {
                var replacements = new Dictionary<string, string>
                {
                    { "UserName", $"{userProfile.FirstName} {(userProfile.LastName ?? "")}".Trim() },
                    { "DateOfJoining", userProfile.DateOfJoining.ToString("dd MMM yyyy") }
                };
                var emailsend = await _emailSenderRepository.SendEmailUsingTemplateAsync(userProfile.Email, EmailTemplateType.StaffCreated, replacements, cancellationToken);
            }
            // Upload profile picture if provided
            if (request.ProfilePicture != null)
            {
                await _fileUploadRepository.UploadProfilePictureAsync(request.ProfilePicture, userProfile.Id);
            }

            return userProfile.Id;
        }
        public async Task<bool> IsAadhaarUnique(string aadhaar)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.AadhaarNumber == aadhaar && !q.IsDeleted);
        }
        public async Task<bool> IsPanUnique(string panCard)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.PanNumber == panCard && !q.IsDeleted);
        }
        public async Task<bool> IsUanNumberUnique(string uanNumber)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.UanNumber == uanNumber && !q.IsDeleted);
        }
        public async Task<bool> IsEsicUnique(string esicNumber)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.EsicNumber == esicNumber && !q.IsDeleted);
        }
        public async Task<bool> IsAadhaarUniqueForUpdate(Guid id, string value)
        {
            return !await _context.UserProfiles
                .Where(q => q.AadhaarNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
        public async Task<bool> IsPanUniqueForUpdate(Guid id, string value)
        {
            return !await _context.UserProfiles
                .Where(q => q.PanNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
        public async Task<bool> IsUanNumberUniqueForUpdate(Guid id, string value)
        {
            return !await _context.UserProfiles
                .Where(q => q.UanNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
        public async Task<bool> IsEsicUniqueForUpdate(Guid id, string value)
        {
            return !await _context.UserProfiles
                .Where(q => q.EsicNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync();
        }
        private UserProfileDto MapToDto(Domain.Entity.Registration.UserProfile response)
        {
            return new UserProfileDto
            {
                Id = response.Id,
                CompanyId = response.CompanyId,
                CompanyName = response.Company.CompanyName ?? string.Empty,
                RegistrationId = response.RegistrationId,
                TitleId = response.TitleId,
                Salutation = response.Salutation != null ? response.Salutation.Name : string.Empty,
                FirstName = response.FirstName,
                MiddleName = response.MiddleName,
                LastName = response.LastName,
                Email = response.Email,
                AadhaarNumber = response.AadhaarNumber,
                PanNumber = response.PanNumber,
                UanNumber = response.UanNumber,
                EsicNumber = response.EsicNumber,
                MobileNumber = response.MobileNumber,
                AlternatePhoneNumber = response.AlternatePhoneNumber,
                DateOfRegistration = response.DateOfRegistration,
                DateOfBirth = response.DateOfBirth,
                PlaceOfBirth = response.PlaceOfBirth,
                DateOfJoining = response.DateOfJoining,
                RecruitmentTypeId = response.RecruitmentTypeId ?? Guid.Empty,
                RecruitmentTypeName = response.RecruitmentType != null ? response.RecruitmentType.Name : string.Empty,
                GenderId = response.GenderId,
                GenderName = response.Gender != null ? response.Gender.Name : string.Empty,
                IdentityMarks = response.IdentityMarks,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
