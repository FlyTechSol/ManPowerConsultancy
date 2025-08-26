using MC.Application.Contracts.Email;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IRegistrationIdGeneratorRepository _registrationIdGeneratorRepository;
        public UserProfileRepository(
            IEmailSenderRepository emailSenderRepository,
            IRegistrationIdGeneratorRepository registrationIdGeneratorRepository,
            ApplicationDatabaseContext context) : base(context)
        {
            _emailSenderRepository = emailSenderRepository;
            _registrationIdGeneratorRepository = registrationIdGeneratorRepository;
        }

        public async Task<UserProfileShortDto?> GetUserProfileByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            return await _context.UserProfiles
                .AsNoTracking()
                .Where(up => up.RegistrationId == registrationId && !up.IsDeleted)
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

        public async Task<Guid> CreateUserProfileAsync(UserProfileDto request)
        {
            var RegId = await _registrationIdGeneratorRepository.GetNextRegistrationIdAsync();

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
                var emailsend = await _emailSenderRepository.SendEmailUsingTemplateAsync(userProfile.Email, EmailTemplateType.StaffCreated, replacements);
            }
            // Upload profile picture if provided
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
    }
}
