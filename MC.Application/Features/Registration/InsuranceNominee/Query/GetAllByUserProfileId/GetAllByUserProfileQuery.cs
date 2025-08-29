using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByUserProfileId
{
    public record GetAllByUserProfileQuery(Guid UserProfileId) : IRequest<List<InsuranceNomineeDetailDto>>;
}
