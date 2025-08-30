using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Category.Query.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<PaginatedResponse<CategoryDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<GetAllCategoriesQueryHandler> _logger;

        public GetAllCategoriesQueryHandler(IMapper mapper,
            ICategoryRepository categoryRepository,
            IAppLogger<GetAllCategoriesQueryHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<CategoryDetailDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _categoryRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<CategoryDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
