using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetByRegistrationId
{
   public record GetByRegistrationIdBodyMeasQuery(string RegistrationId) : IRequest<BodyMeasurementDetailDto>;
}
