using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetById
{
   public record GetByIdZipCodeQuery(Guid Id) : IRequest<ZipCodeDetailDto>;
}
