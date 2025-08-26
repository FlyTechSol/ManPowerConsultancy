using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetById
{
    public class GetByIdReligionQueryHandler : IRequestHandler<GetByIdReligionQuery, ReligionDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IReligionRepository _religionRepository;

        public GetByIdReligionQueryHandler(IMapper mapper, IReligionRepository religionRepository)
        {
            _mapper = mapper;
            _religionRepository = religionRepository;
        }

        public async Task<ReligionDetailDto> Handle(GetByIdReligionQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _religionRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<ReligionDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
