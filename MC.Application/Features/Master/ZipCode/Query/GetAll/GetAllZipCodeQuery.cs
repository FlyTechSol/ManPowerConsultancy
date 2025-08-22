using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetAll
{
    public record GetAllZipCodeQuery : IRequest<List<ZipCodeDto>>;
}
