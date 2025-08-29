using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetById
{
    public record GetUserGeneralByIdQuery(Guid Id) : IRequest<UserGeneralDetailDto>;
}
