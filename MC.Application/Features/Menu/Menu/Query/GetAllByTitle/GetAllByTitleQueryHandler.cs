using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetAllByTitle
{
   public class GetAllByTitleQueryHandler : IRequestHandler<GetAllByTitleQuery, List<MenuTitleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly IAppLogger<GetAllByTitleQueryHandler> _logger;

        public GetAllByTitleQueryHandler(IMapper mapper,
            IMenuRepository menuRepository,
            IAppLogger<GetAllByTitleQueryHandler> logger)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<List<MenuTitleDto>> Handle(GetAllByTitleQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _menuRepository.GetAllMenuTitleAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<MenuTitleDto>>(response);

            // return list of DTO object
            _logger.LogInformation("Menu title were retrieved successfully");
            return data;
        }
    }
}
