using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public InsuranceRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<InsuranceDetailDto>?> GetInsuranceByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.Insurances
                .AsNoTracking()
                .Where(response => response.UserProfileId == userProfile.Id && !response.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<InsuranceDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<InsuranceDetailDto>?> GetInsuranceByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.Insurances
                .AsNoTracking()
                .Where(response => response.UserProfileId == userProfileId && !response.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<InsuranceDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<InsuranceDetailDto?> GetInsuranceByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Insurances
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private InsuranceDetailDto MapToDto(Domain.Entity.Registration.Insurance response)
        {
            return new InsuranceDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                InsuranceCompanyName = response.InsuranceCompanyName,
                PolicyNumber = response.PolicyNumber,
                PolicyStartDate = response.PolicyStartDate,
                PolicyEndDate = response.PolicyEndDate,
                PolicyRemarks = response.PolicyRemarks,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}

