using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetById
{
    public record GetByIdQuery(Guid Id) : IRequest<PreviousExperienceDetailDto>;
}
