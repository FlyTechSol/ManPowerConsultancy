using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetById
{
   public record GetBodyMeasurementByIdQuery(Guid Id) : IRequest<BodyMeasurementDetailDto>;
}
