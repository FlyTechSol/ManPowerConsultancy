using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetById
{
   public record GetFamilyByIdQuery(Guid Id) : IRequest<FamilyDetailDto>;
}
