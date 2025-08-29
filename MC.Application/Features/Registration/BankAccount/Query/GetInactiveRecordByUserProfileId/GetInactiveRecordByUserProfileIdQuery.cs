using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByUserProfileId
{
    public record GetInactiveRecordByUserProfileIdQuery(Guid UserProfileId) : IRequest<List<BankAccountDetailDto>>;
}
