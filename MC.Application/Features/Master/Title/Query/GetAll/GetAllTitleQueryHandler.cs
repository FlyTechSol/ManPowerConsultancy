using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetAll
{
    public class GetAllTitleQueryHandler : IRequestHandler<GetAllTitleQuery, List<TitleDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly IAppLogger<GetAllTitleQueryHandler> _logger;

        public GetAllTitleQueryHandler(IMapper mapper,
            ITitleRepository titleRepository,
            IAppLogger<GetAllTitleQueryHandler> logger)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _logger = logger;
        }

        public async Task<List<TitleDto>> Handle(GetAllTitleQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var title = await _titleRepository.GetAllDetailsAsync(request.IsMale, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<TitleDto>>(title);

            // return list of DTO object
            _logger.LogInformation("Title were retrieved successfully");
            return data;
        }
    }
}
