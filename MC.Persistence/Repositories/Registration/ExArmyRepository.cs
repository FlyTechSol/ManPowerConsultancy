using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class ExArmyRepository : GenericRepository<ExArmy>, IExArmyRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public ExArmyRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<ExArmyDetailDto?> GetAllExArmyByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.ExArmies
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new ExArmyDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    ServiceNumber = ex.ServiceNumber,
                    Rank = ex.Rank,
                    Unit = ex.Unit,
                    BranchOfService = ex.BranchOfService,
                    TotalService = ex.TotalService,
                    EnlistmentDate = ex.EnlistmentDate,
                    DischargeDate = ex.DischargeDate,
                    ReasonForDischarge = ex.ReasonForDischarge,
                    DischargeCertificateUrl = ex.DischargeCertificateUrl,
                    IsActive =ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ExArmies
                .AsNoTracking()
                .Include(ex=>ex.UserProfile) 
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new ExArmyDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty, 
                ServiceNumber = response.ServiceNumber,
                Rank = response.Rank,
                Unit = response.Unit,
                BranchOfService = response.BranchOfService,
                TotalService = response.TotalService,
                EnlistmentDate = response.EnlistmentDate,
                DischargeDate = response.DischargeDate,
                ReasonForDischarge = response.ReasonForDischarge,
                DischargeCertificateUrl = response.DischargeCertificateUrl,
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
