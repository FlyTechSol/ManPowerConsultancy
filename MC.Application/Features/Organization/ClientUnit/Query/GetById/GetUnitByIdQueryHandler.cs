using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetById
{
    public class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, UnitDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;

        public GetUnitByIdQueryHandler(IMapper mapper, IUnitRepository unitRepository)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
        }

        public async Task<UnitDetailDto> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _unitRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(ClientUnit), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<UnitDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
