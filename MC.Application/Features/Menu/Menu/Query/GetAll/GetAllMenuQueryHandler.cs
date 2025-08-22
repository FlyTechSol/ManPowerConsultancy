using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetAll
{
   public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQuery, List<MenuDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly IAppLogger<GetAllMenuQueryHandler> _logger;

        public GetAllMenuQueryHandler(IMapper mapper,
            IMenuRepository menuRepository,
            IAppLogger<GetAllMenuQueryHandler> logger)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<List<MenuDto>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _menuRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<MenuDto>>(response);

            // return list of DTO object
            _logger.LogInformation("Menu were retrieved successfully");
            return data;
        }
    }
}
