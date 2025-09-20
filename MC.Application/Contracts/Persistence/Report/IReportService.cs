using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Report;

namespace MC.Application.Contracts.Persistence.Report
{
    public interface IReportService
    {
        Task<PaginatedResponse<StaffDto>> GetStaffReportAsync(StaffFilterDto filter, CancellationToken cancellationToken);
    }
}
