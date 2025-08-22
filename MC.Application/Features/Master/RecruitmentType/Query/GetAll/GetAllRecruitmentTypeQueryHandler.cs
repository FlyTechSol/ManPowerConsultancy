using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetAll
{
    public class GetAllRecruitmentTypeQueryHandler : IRequestHandler<GetAllRecruitmentTypeQuery, List<RecruitmentTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;
        private readonly IAppLogger<GetAllRecruitmentTypeQueryHandler> _logger;

        public GetAllRecruitmentTypeQueryHandler(IMapper mapper,
            IRecruitmentTypeRepository recruitmentTypeRepository,
            IAppLogger<GetAllRecruitmentTypeQueryHandler> logger)
        {
            _mapper = mapper;
            _recruitmentTypeRepository = recruitmentTypeRepository;
            _logger = logger;
        }

        public async Task<List<RecruitmentTypeDto>> Handle(GetAllRecruitmentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _recruitmentTypeRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<RecruitmentTypeDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Recruitment Type were retrieved successfully");
            return data;
        }
    }
}
