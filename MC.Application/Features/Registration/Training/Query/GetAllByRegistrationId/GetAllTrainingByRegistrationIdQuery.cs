using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Training.Query.GetAllByRegistrationId
{
    public record GetAllTrainingByRegistrationIdQuery(int RegistrationId) : IRequest<TrainingDetailDto>;
}
