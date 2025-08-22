using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    internal class InsuranceNomineeRepository : GenericRepository<InsuranceNominee>, IInsuranceNomineeRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public InsuranceNomineeRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<InsuranceNomineeDetailDto?> GetAllInsuranceNomineeByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.InsuranceNominees
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new InsuranceNomineeDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    NominatedBy = ex.NominatedBy,
                    NominatedByFather = ex.NominatedByFather,
                    SoldierNumber = ex.SoldierNumber,
                    SoldierRank = ex.SoldierRank,
                    SoldierUnit = ex.SoldierUnit,
                    NominatedByDoB = ex.NominatedByDoB,
                    NominatedByPermanentAddress = ex.NominatedByPermanentAddress,
                    NominatedByCorrespondenceAddress = ex.NominatedByCorrespondenceAddress,
                    NomineeName = ex.NomineeName,
                    RelationWithNominee = ex.RelationWithNominee,
                    NomineeFather = ex.NomineeFather,
                    NomineeDoB = ex.NomineeDoB,
                    NomineeByPermanentAddress = ex.NomineeByPermanentAddress,
                    NomineeByCorrespondenceAddress = ex.NomineeByCorrespondenceAddress,
                    IsActive = ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<InsuranceNomineeDetailDto?> GetInsuranceNomineeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.InsuranceNominees
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new InsuranceNomineeDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                NominatedBy = response.NominatedBy,
                NominatedByFather = response.NominatedByFather,
                SoldierNumber = response.SoldierNumber,
                SoldierRank = response.SoldierRank,
                SoldierUnit = response.SoldierUnit,
                NominatedByDoB = response.NominatedByDoB,
                NominatedByPermanentAddress = response.NominatedByPermanentAddress,
                NominatedByCorrespondenceAddress = response.NominatedByCorrespondenceAddress,
                NomineeName = response.NomineeName,
                RelationWithNominee = response.RelationWithNominee,
                NomineeFather = response.NomineeFather,
                NomineeDoB = response.NomineeDoB,
                NomineeByPermanentAddress = response.NomineeByPermanentAddress,
                NomineeByCorrespondenceAddress = response.NomineeByCorrespondenceAddress,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
            return dto;
        }
    }
}