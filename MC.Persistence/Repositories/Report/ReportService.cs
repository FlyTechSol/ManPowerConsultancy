using MC.Application.Contracts.Persistence.Report;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Report;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Report
{
    public class ReportService : IReportService
    {
        protected readonly ApplicationDatabaseContext _context;
        public ReportService(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResponse<StaffDto>> GetStaffReportAsync(StaffFilterDto filter, CancellationToken cancellationToken)
        {
            var query = _context.UserProfiles
                .AsNoTracking()
                .Include(x => x.UserGeneralDetail)
                    .ThenInclude(x => x.Religion)
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
            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                var search = filter.Query.ToLower();
                query = query.Where(q =>
                    q.FirstName.ToLower().Contains(search) ||
                    (!string.IsNullOrWhiteSpace(q.RegistrationId) && q.RegistrationId.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.MiddleName) && q.MiddleName.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.LastName) && q.LastName.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.AadhaarNumber) && q.AadhaarNumber.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.PanNumber) && q.PanNumber.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.EsicNumber) && q.EsicNumber.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.UanNumber) && q.UanNumber.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.Email) && q.Email.ToLower().Contains(search)) ||
                    (!string.IsNullOrWhiteSpace(q.MobileNumber) && q.MobileNumber.ToLower().Contains(search))
                );
            }

            if (filter.CompanyId.HasValue && filter.CompanyId.Value != Guid.Empty)
                query = query.Where(q => q.CompanyId == filter.CompanyId);

            if (filter.ClientMasterId.HasValue && filter.ClientMasterId.Value != Guid.Empty)
                query = query.Where(q => q.ClientMasterId == filter.ClientMasterId);

            if (filter.ClientUnitId.HasValue && filter.ClientUnitId.Value != Guid.Empty)
                query = query.Where(q => q.ClientUnitId == filter.ClientUnitId);

            if (filter.BarnchId.HasValue && filter.BarnchId.Value != Guid.Empty)
                query = query.Where(q => q.BranchId == filter.BarnchId);

            if (filter.DesignationId.HasValue && filter.DesignationId.Value != Guid.Empty)
                query = query.Where(q => q.DesignationId == filter.DesignationId);

            if (filter.CategoryId.HasValue && filter.CategoryId.Value != Guid.Empty)
                query = query.Where(q => q.CategoryId == filter.CategoryId);

            if (filter.IsActive.HasValue)
                query = query.Where(q => q.IsActive == filter.IsActive.Value);

            // total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(filter.Column))
            {
                string direction = filter.Dir?.ToLower() == "desc" ? "descending" : "";
                query = query.OrderBy($"{filter.Column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.RegistrationId); // default sort
            }

            // Data
            List<Domain.Entity.Registration.UserProfile> data;

            if (filter.IsExport)
            {
                data = await query.ToListAsync(cancellationToken);
            }
            else
            {
                var skip = (filter.Page - 1) * filter.Limit;
                data = await query.Skip(skip)
                                  .Take(filter.Limit)
                                  .ToListAsync(cancellationToken);
            }

            // Map
            var dtos = data.Select(MapToDto).ToList();

            var totalPages = filter.IsExport
                ? 1 // everything in one page
                : (int)Math.Ceiling(totalCount / (double)filter.Limit);

            return new PaginatedResponse<StaffDto>
            {
                Data = dtos,
                CurrentPage = filter.Page,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }

        private StaffDto MapToDto(Domain.Entity.Registration.UserProfile response)
        {
            return new StaffDto
            {
                Id = response.Id,
                RegistrationNumber = response.RegistrationId ?? string.Empty,
                StaffName = Helper.UserHelper.GetFullName(response.Salutation != null ? response.Salutation.Name : string.Empty,
                                                            response.FirstName,
                                                            response.MiddleName ?? string.Empty,
                                                            response.LastName ?? string.Empty),
                Gender = response.Gender != null ? response.Gender.Name : string.Empty,
                Company = response.Company != null ? response.Company.CompanyName : string.Empty,
                ClientMaster = response.ClientMaster != null ? response.ClientMaster.ClientName : string.Empty,
                ClientUnit = response.ClientUnit != null ? response.ClientUnit.UnitName : string.Empty,
                Branch = response.Branch != null ? response.Branch.Name : string.Empty,
                Designation = response.Designation != null ? response.Designation.Name : string.Empty,
                Category = response.Category != null ? response.Category.Name : string.Empty,
                AadhaarNumber = response.AadhaarNumber ?? string.Empty,
                PanCard = response.PanNumber ?? string.Empty,
                UanNumber = response.UanNumber ?? string.Empty,
                EsicNumber = response.EsicNumber ?? string.Empty,
                DateOfBirth = response.DateOfBirth,
                DateOfJoining = response.DateOfJoining,
                Email = response.Email,
                Mobile = response.MobileNumber,
                IsActive = response.IsActive,
                FatherName = response.UserGeneralDetail != null ? response.UserGeneralDetail.FatherName : string.Empty,
                MotherName = response.UserGeneralDetail != null ? response.UserGeneralDetail.MotherName : string.Empty,
                SpouseName = response.UserGeneralDetail != null ? response.UserGeneralDetail.SpouseName : string.Empty,
                Religion = response.UserGeneralDetail != null && response.UserGeneralDetail.Religion !=null ? response.UserGeneralDetail.Religion.Name : string.Empty,
                Nationality = response.UserGeneralDetail != null && response.UserGeneralDetail.Nationality != null ? response.UserGeneralDetail.Nationality.Name : string.Empty,
                CasteCategory = response.UserGeneralDetail != null && response.UserGeneralDetail.CasteCategory != null ? response.UserGeneralDetail.CasteCategory.Name : string.Empty,
                HighestEducation = response.UserGeneralDetail != null && response.UserGeneralDetail.HighestEducation != null ? response.UserGeneralDetail.HighestEducation.Name : string.Empty,
                MaritalStatus = response.UserGeneralDetail != null ? response.UserGeneralDetail.MaritalStatus.ToString() : string.Empty,
                DifferentlyAbled = response.UserGeneralDetail != null && response.UserGeneralDetail.DifferentlyAbled
            };
        }
    }
}
