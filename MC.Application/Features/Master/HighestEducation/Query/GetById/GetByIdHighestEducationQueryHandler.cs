using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetById
{
    public class GetByIdHighestEducationQueryHandler : IRequestHandler<GetByIdHighestEducationQuery, HighestEducationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IHighestEducationRepository _highestEducationRepository;

        public GetByIdHighestEducationQueryHandler(IMapper mapper, IHighestEducationRepository highestEducationRepository)
        {
            _mapper = mapper;
            _highestEducationRepository = highestEducationRepository;
        }

        public async Task<HighestEducationDetailDto> Handle(GetByIdHighestEducationQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _highestEducationRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(HighestEducation), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<HighestEducationDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
