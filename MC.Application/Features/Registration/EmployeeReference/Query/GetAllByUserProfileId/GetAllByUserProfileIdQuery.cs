using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetAllByUserProfileId
{
    public record GetAllByUserProfileIdQuery(Guid UserProfileId) : IRequest<List<EmployeeReferenceDetailDto>>;
}
