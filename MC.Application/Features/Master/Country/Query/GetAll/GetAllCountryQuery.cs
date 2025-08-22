using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetAll
{
   public record GetAllCountryQuery : IRequest<List<CountryDto>>;
}
