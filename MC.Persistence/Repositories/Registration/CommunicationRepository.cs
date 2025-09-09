using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class CommunicationRepository : GenericRepository<Communication>, ICommunicationRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public CommunicationRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }
        
        public async Task<CommunicationDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.Communications
                .AsNoTracking()
                .Where(communication => communication.UserProfileId == userProfile.Id && !communication.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        //public async Task<PaginatedResponse<CommunicationDetailDto>?> GetCommunicationByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        //{
        //    var query = _context.Communications
        //        .AsNoTracking()
        //        .Where(communication => communication.UserProfileId == userProfileId && !communication.IsDeleted);
        //    // Search filter
        //    if (!string.IsNullOrWhiteSpace(queryParams.Query))
        //    {
        //        var search = queryParams.Query.ToLower();
        //        query = query.Where(q =>
        //            q.PersonalMobileNumber.ToLower().Contains(search) ||
        //            q.OfficialMobileNumber != null && q.OfficialMobileNumber.ToLower().Contains(search) ||
        //            (q.PersonalEmail != null && q.PersonalEmail.ToLower().Contains(search)) ||
        //            (q.OfficialEmail != null && q.OfficialEmail.ToLower().Contains(search))
        //        );
        //    }
        //    // Total count before pagination
        //    var totalCount = await query.CountAsync(cancellationToken);

        //    // Sorting
        //    if (!string.IsNullOrWhiteSpace(queryParams.Column))
        //    {
        //        string column = queryParams.Column;
        //        string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

        //        query = query.OrderBy($"{column} {direction}");
        //    }
        //    else
        //    {
        //        query = query.OrderBy(a => a.Rank); // default sort
        //    }

        //}
        public async Task<CommunicationDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.Communications
                .AsNoTracking()
                .Where(communication => communication.UserProfileId == userProfileId && !communication.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<CommunicationDetailDto?> GetCommunicationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Communications
                .AsNoTracking()
                .Where(communication => communication.Id == id && !communication.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private CommunicationDetailDto MapToDto(Domain.Entity.Registration.Communication communication)
        {
            return new CommunicationDetailDto
            {
                Id = communication.Id,
                UserProfileId = communication.UserProfileId,
                UserProfileName = communication.UserProfile.FirstName + " " + communication.UserProfile.LastName,
                PersonalMobileNumber = communication.PersonalMobileNumber,
                OfficialMobileNumber = communication.OfficialMobileNumber,
                EmergencyContactNumber = communication.EmergencyContactNumber,
                LandlineNumber1 = communication.LandlineNumber1,
                LandlineNumber2 = communication.LandlineNumber2,
                PersonalEmail = communication.PersonalEmail,
                OfficialEmail = communication.OfficialEmail,
                IsActive = communication.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(communication.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(communication.DateModified),
                CreatedByName = communication.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = communication.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
