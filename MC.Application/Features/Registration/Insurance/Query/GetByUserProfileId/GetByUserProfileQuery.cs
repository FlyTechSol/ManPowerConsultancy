using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Query.GetByUserProfileId
{
   public record GetByUserProfileQuery(Guid UserProfileId) : IRequest<List<InsuranceDetailDto>>;
}
