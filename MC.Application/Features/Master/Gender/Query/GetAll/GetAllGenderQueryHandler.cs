using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetAll
{
    public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQuery, List<GenderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly IAppLogger<GetAllGenderQueryHandler> _logger;

        public GetAllGenderQueryHandler(IMapper mapper,
            IGenderRepository genderRepository,
            IAppLogger<GetAllGenderQueryHandler> logger)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _logger = logger;
        }

        public async Task<List<GenderDto>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var gender = await _genderRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<GenderDto>>(gender);

            // return list of DTO object
            _logger.LogInformation("Gender were retrieved successfully");
            return data;
        }
    }
}
