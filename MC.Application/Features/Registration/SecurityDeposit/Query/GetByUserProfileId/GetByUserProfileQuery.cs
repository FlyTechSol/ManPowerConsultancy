using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Query.GetByUserProfileId
{
    public record GetByUserProfileQuery(Guid UserProfileId) : IRequest<SecurityDepositDetailDto>;
}
