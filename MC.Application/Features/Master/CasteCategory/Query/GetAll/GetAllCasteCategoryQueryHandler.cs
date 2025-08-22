using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetAll
{
    public class GetAllCasteCategoryQueryHandler : IRequestHandler<GetAllCasteCategoryQuery, List<CasteCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICasteCategoryRepository _casteCategoryRepository;
        private readonly IAppLogger<GetAllCasteCategoryQueryHandler> _logger;

        public GetAllCasteCategoryQueryHandler(IMapper mapper,
            ICasteCategoryRepository casteCategoryRepository,
            IAppLogger<GetAllCasteCategoryQueryHandler> logger)
        {
            _mapper = mapper;
            _casteCategoryRepository = casteCategoryRepository;
            _logger = logger;
        }

        public async Task<List<CasteCategoryDto>> Handle(GetAllCasteCategoryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _casteCategoryRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<CasteCategoryDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Caste category were retrieved successfully");
            return data;
        }
    }
}
