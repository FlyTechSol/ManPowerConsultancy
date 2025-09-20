using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.DownloadExArmyCertificate
{
    public record DownloadExArmyCertQuery(Guid ExArmyId) : IRequest<FileResponseDto>;
}
