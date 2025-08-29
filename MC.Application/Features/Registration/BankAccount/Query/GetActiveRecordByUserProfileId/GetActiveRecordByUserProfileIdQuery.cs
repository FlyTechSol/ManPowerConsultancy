using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByUserProfileId
{
   public record GetActiveRecordByUserProfileIdQuery(Guid UserProfileId) : IRequest<BankAccountDetailDto>;
}
