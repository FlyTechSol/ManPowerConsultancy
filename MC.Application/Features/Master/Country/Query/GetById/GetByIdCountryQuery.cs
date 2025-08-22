using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Country.Query.GetById
{
    public record GetByIdCountryQuery(Guid Id) : IRequest<CountryDetailDto>;
}
