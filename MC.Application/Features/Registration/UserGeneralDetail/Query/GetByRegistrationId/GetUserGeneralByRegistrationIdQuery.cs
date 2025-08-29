using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetByRegistrationId
{
   public record GetUserGeneralByRegistrationIdQuery(string RegistrationId) : IRequest<UserGeneralDetailDto>;
}
