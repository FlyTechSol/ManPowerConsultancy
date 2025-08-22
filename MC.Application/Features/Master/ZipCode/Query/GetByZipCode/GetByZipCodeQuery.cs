using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetByZipCode
{
  public record GetByZipCodeQuery(string zipCode) : IRequest<ZipCodeDetailDto>;
}
