using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Designation.Query.GetById
{
     public record GetDesignationByIdQuery(Guid Id) : IRequest<DesignationDetailDto>;
}
