using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetById
{
   public record GetResignationByIdQuery(Guid Id) : IRequest<ResignationDetailDto>;
}
