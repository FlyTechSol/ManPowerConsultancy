using MC.Application.Contracts.Persistence.Common.Download;
using MC.Application.Contracts.Persistence.Report;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Report
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _report;
        private readonly ICsvExportService _csvExprt;
        private readonly IPdfExportService _pdfExprt;

        public ReportController(IReportService report, ICsvExportService csvExprt, IPdfExportService pdfExprt)
        {
            this._report = report;
            this._csvExprt = csvExprt;
            this._pdfExprt = pdfExprt;
        }

        [HttpPost("staff-report")]
        public async Task<ActionResult<PaginatedResponse<StaffDto>>> GetStaffAsync([FromBody] StaffFilterDto filter, CancellationToken cancellationToken)
        {
            filter.IsExport = false;
            var result = await _report.GetStaffReportAsync(filter, cancellationToken);
            return Ok(result);
        }
        [HttpPost("staff-report/export-pdf")]
        public async Task<IActionResult> StaffReportPdfAsync([FromBody] StaffFilterDto filter, CancellationToken cancellationToken)
        {
            filter.IsExport = true;

            var result = await _report.GetStaffReportAsync(filter, cancellationToken);

            var pdfBytes = _pdfExprt.GeneratePdf(result.Data, "Total Staff Registration");

            return File(pdfBytes, "application/pdf", "staff-report.pdf");
        }

        [HttpPost("staff-report/export-csv")]
        public async Task<IActionResult> StaffReportCsvAsync([FromBody] StaffFilterDto filter, CancellationToken cancellationToken)
        {
            filter.IsExport = true;

            var result = await _report.GetStaffReportAsync(filter, cancellationToken);

            var csvBytes = _csvExprt.ExportToCsv(result.Data);

            return File(csvBytes, "text/csv", "staff-report.csv");
        }
    }
}