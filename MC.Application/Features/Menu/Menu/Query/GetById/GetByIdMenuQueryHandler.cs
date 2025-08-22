using AutoMapper;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetById
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQuery, MenuDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public GetByIdMenuQueryHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<MenuDetailDto> Handle(GetByIdMenuQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _menuRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Menu), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<MenuDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
