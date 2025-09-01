using MC.Application.Contracts.Persistence.Menu;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetAll
{
    public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQuery, ApiResponse<PaginatedResponse<MenuDto>>>
    {
        private readonly IMenuRepository _menuRepository;
     
        public GetAllMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<ApiResponse<PaginatedResponse<MenuDto>>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
        {
            var record = await _menuRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<MenuDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
