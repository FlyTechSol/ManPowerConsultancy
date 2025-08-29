using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetByUserProfileId
{
    public record GetByUserProfileIdQuery(Guid UserProfileId) : IRequest<BodyMeasurementDetailDto>;
}
