using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetByUserProfileId
{
   public record GetByUserProfileQuery(Guid UserProfileId) : IRequest<ResignationDetailDto>;
}
