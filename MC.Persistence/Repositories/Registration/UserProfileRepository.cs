using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Threading;

namespace MC.Persistence.Repositories.Registration
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IRegistrationIdGeneratorRepository _registrationIdGeneratorRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        private readonly IApprovalRequestRepository _approvalRequestRepository;
        public UserProfileRepository(
           IEmailSenderRepository emailSenderRepository,
           IRegistrationIdGeneratorRepository registrationIdGeneratorRepository,
           IFileUploadRepository fileUploadRepository,
           IApprovalRequestRepository approvalRequestRepository,
           ApplicationDatabaseContext context) : base(context)
        {
            _emailSenderRepository = emailSenderRepository;
            _registrationIdGeneratorRepository = registrationIdGeneratorRepository;
            _fileUploadRepository = fileUploadRepository;
            _approvalRequestRepository = approvalRequestRepository;
        }

        public async Task<UserProfileDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var response = await _context.UserProfiles
                .AsNoTracking()
                .Include(x => x.Company)
                .Include(x => x.ClientMaster)
                .Include(x => x.ClientUnit)
                .Include(x => x.Category)
                .Include(x => x.Branch)
                .Include(x => x.Designation)
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
                .Include(x => x.ClientMaster)
                .Include(x => x.ClientUnit)
                .Include(x => x.Category)
                .Include(x => x.Branch)
                .Include(x => x.Designation)
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
                .Include(x => x.Company)
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
                    CompanyName = up.Company != null ? up.Company.CompanyName ?? string.Empty : string.Empty,
                    ProfilePictureUrl = up.ProfilePictureUrl,
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginatedResponse<UserProfileDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.UserProfiles
                .AsNoTracking()
                .Include(x => x.Company)
                .Include(x => x.ClientMaster)
                .Include(x => x.ClientUnit)
                .Include(x => x.Category)
                .Include(x => x.Branch)
                .Include(x => x.Designation)
                .Include(x => x.RecruitmentType)
                .Include(x => x.Salutation)
                .Include(x => x.Gender)
                .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.RegistrationId) && q.RegistrationId.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.MiddleName) && q.MiddleName.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.LastName) && q.LastName.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.AadhaarNumber) && q.AadhaarNumber.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.PanNumber) && q.PanNumber.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.EsicNumber) && q.EsicNumber.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.UanNumber) && q.UanNumber.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.Email) && q.Email.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.MobileNumber) && q.MobileNumber.ToLower().Contains(search)
                );
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.DateCreated); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<UserProfileDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<Guid> CreateUserProfileAsync(UserProfile userProfile, Guid loggedInUserId, IFormFile? profilePicture, CancellationToken cancellationToken)
        {
            if (userProfile.CompanyId.HasValue)
            {
                var regId = await _registrationIdGeneratorRepository
                    .GetNextRegistrationIdAsync(userProfile.CompanyId.Value);
                userProfile.RegistrationId = regId;
            }
            else
            {
                userProfile.RegistrationId = null;
            }

            if (userProfile.DateOfJoining == default(DateTime))
            {
                userProfile.DateOfJoining = DateTime.UtcNow.Date;
            }
            userProfile.IsActive = true;

            // Save to database
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            // Handle Profile Picture (after Id is generated)
            if (profilePicture != null)
            {
                var url = await _fileUploadRepository.UploadProfilePictureAsync(profilePicture, userProfile.Id, cancellationToken);
                userProfile.ProfilePictureUrl = url;

                _context.UserProfiles.Update(userProfile);
                await _context.SaveChangesAsync(cancellationToken);
            }

            //create approval step
            // 4. Create Approval Request
            if (userProfile.CompanyId.HasValue)
            {
                var workflow = await _context.ApprovalWorkflows
                    .Include(w => w.Stages)
                    .ThenInclude(s => s.Approvers)
                    .FirstOrDefaultAsync(w => w.WorkflowType == WorkflowType.StaffApproval &&
                                              w.CompanyId == userProfile.CompanyId.Value,
                                           cancellationToken);

                if (workflow != null)
                {
                    var approvalRequest = await _approvalRequestRepository.CreateApprovalRequestAsync(
                        workflow.Id,
                        loggedInUserId,
                        RequestType.ProfileApproval,
                        userProfile.Id,
                        cancellationToken);

                    var stages = workflow.Stages.OrderBy(s => s.Order).ToList();
                    await _approvalRequestRepository.AddApprovalRequestStagesAsync(approvalRequest, stages, cancellationToken);
                }
            }

            // Send email
            if (!string.IsNullOrWhiteSpace(userProfile.Email))
            {
                var replacements = new Dictionary<string, string>
                {
                    { "UserName", $"{userProfile.FirstName} {(userProfile.LastName ?? "")}".Trim() },
                     { "DateOfJoining", userProfile.DateOfJoining.HasValue
                                    ? userProfile.DateOfJoining.Value.ToString("dd MMM yyyy")
            :                       "Not Assigned" }
                };
                var emailsend = await _emailSenderRepository.SendEmailUsingTemplateAsync(userProfile.Email, EmailTemplateType.StaffCreated, replacements, cancellationToken);
            }
            return userProfile.Id;

        }

        public async Task<Guid> UpdateUserProfileAsync(UserProfile userProfile, IFormFile? profilePicture, CancellationToken cancellationToken)
        {
            var existing = await _context.UserProfiles
                .FirstOrDefaultAsync(x => x.Id == userProfile.Id, cancellationToken);

            if (existing == null)
                throw new NotFoundException($"UserProfile with Id {userProfile.Id} not found", userProfile.Id);

            //existing.UserId = userProfile.UserId;
            existing.TitleId = userProfile.TitleId;
            existing.CompanyId = userProfile.CompanyId;
            existing.ClientMasterId = userProfile.ClientMasterId;
            existing.ClientUnitId = userProfile.ClientUnitId;
            existing.BranchId = userProfile.BranchId;
            existing.ClientUnitId = userProfile.ClientUnitId;
            existing.RecruitmentTypeId = userProfile.RecruitmentTypeId;
            existing.PlaceOfBirth = userProfile.PlaceOfBirth;
            existing.AlternatePhoneNumber = userProfile.AlternatePhoneNumber;
            existing.GenderId = userProfile.GenderId;
            existing.DateOfRegistration = userProfile.DateOfRegistration;
            existing.IdentityMarks = userProfile.IdentityMarks;
            existing.FirstName = userProfile.FirstName;
            existing.MiddleName = userProfile.MiddleName;
            existing.LastName = userProfile.LastName;
            existing.Email = userProfile.Email;
            existing.MobileNumber = userProfile.MobileNumber;
            existing.AadhaarNumber = userProfile.AadhaarNumber;
            existing.PanNumber = userProfile.PanNumber;
            existing.UanNumber = userProfile.UanNumber;
            existing.EsicNumber = userProfile.EsicNumber;
            existing.DesignationId = userProfile.DesignationId;
            existing.CategoryId = userProfile.CategoryId;
            existing.DateOfBirth = userProfile.DateOfBirth;
            existing.DateOfJoining = userProfile.DateOfJoining == default ? existing.DateOfJoining : userProfile.DateOfJoining;
            existing.IsActive = userProfile.IsActive;


            // Handle Profile Picture (replace if new one uploaded)
            if (profilePicture != null)
            {
                var url = await _fileUploadRepository.UploadProfilePictureAsync(profilePicture, existing.Id, cancellationToken);
                existing.ProfilePictureUrl = url;
            }

            _context.UserProfiles.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }

        public async Task<bool> IsAadhaarUnique(string aadhaar, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.AadhaarNumber == aadhaar && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsPanUnique(string panCard, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.PanNumber == panCard && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUanNumberUnique(string uanNumber, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.UanNumber == uanNumber && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsEsicUnique(string esicNumber, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles.AnyAsync(q => q.EsicNumber == esicNumber && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsAadhaarUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles
                .Where(q => q.AadhaarNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync(cancellationToken);
        }
        public async Task<bool> IsPanUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles
                .Where(q => q.PanNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync(cancellationToken);
        }
        public async Task<bool> IsUanNumberUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles
                .Where(q => q.UanNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync(cancellationToken);
        }
        public async Task<bool> IsEsicUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.UserProfiles
                .Where(q => q.EsicNumber == value
                            && q.Id != id
                            && !q.IsDeleted)  // Exclude deleted records
                .AnyAsync(cancellationToken);
        }
        private UserProfileDto MapToDto(Domain.Entity.Registration.UserProfile response)
        {
            return new UserProfileDto
            {
                Id = response.Id,
                RegistrationId = response.RegistrationId ?? string.Empty,
                CompanyId = response.CompanyId,
                CompanyName = response.Company?.CompanyName ?? string.Empty,
                ClientMasterId = response.ClientMasterId,
                ClientMaster = response.ClientMaster?.ClientName ?? string.Empty,
                ClientUnitId = response.ClientUnitId,
                ClientUnit = response.ClientUnit?.UnitName ?? string.Empty,
                BranchId = response.BranchId,
                Branch = response.Branch?.Name ?? string.Empty,
                DesignationId = response.DesignationId,
                Designation = response.Designation?.Name ?? string.Empty,
                CategoryId = response.CategoryId,
                Category = response.Category?.Name ?? string.Empty,
                TitleId = response.TitleId,
                Salutation = response.Salutation != null ? response.Salutation.Name : string.Empty,
                FullName = Helper.UserHelper.GetFullName(response.Salutation != null ? response.Salutation.Name : string.Empty,
                                                            response.FirstName,
                                                            response.MiddleName ?? string.Empty,
                                                            response.LastName ?? string.Empty),
                FirstName = response.FirstName,
                MiddleName = response.MiddleName,
                LastName = response.LastName,
                RecruitmentTypeId = response.RecruitmentTypeId ?? Guid.Empty,
                RecruitmentType = response.RecruitmentType != null ? response.RecruitmentType.Name : string.Empty,
                AadhaarNumber = response.AadhaarNumber,
                PanNumber = response.PanNumber,
                UanNumber = response.UanNumber,
                EsicNumber = response.EsicNumber,
                Email = response.Email,
                MobileNumber = response.MobileNumber,
                AlternatePhoneNumber = response.AlternatePhoneNumber,
                DateOfRegistration = response.DateOfRegistration,
                DateOfBirth = response.DateOfBirth,
                PlaceOfBirth = response.PlaceOfBirth,
                DateOfJoining = response.DateOfJoining,
                GenderId = response.GenderId,
                Gender = response.Gender != null ? response.Gender.Name : string.Empty,
                IdentityMarks = response.IdentityMarks,
                IsActive = response.IsActive,
                ProfilePictureUrl = response.ProfilePictureUrl ?? string.Empty,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
