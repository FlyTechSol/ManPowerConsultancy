using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetByRegistrationId
{
   public record GetByRegistrationIdBodyMeasQuery(int RegistrationId) : IRequest<BodyMeasurementDetailDto>;
}
