using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.DownloadAgencyCertificate
{
    public record DownloadAgencyCertificateQuery(Guid EmpVerificationId) : IRequest<FileResponseDto>;
}
