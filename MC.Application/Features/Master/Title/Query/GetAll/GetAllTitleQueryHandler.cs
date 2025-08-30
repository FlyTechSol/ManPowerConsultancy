using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetAll
{
    public class GetAllTitleQueryHandler : IRequestHandler<GetAllTitleQuery, ApiResponse<PaginatedResponse<TitleDetailDto>>>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IAppLogger<GetAllTitleQueryHandler> _logger;

        public GetAllTitleQueryHandler(
            ITitleRepository titleRepository,
            IAppLogger<GetAllTitleQueryHandler> logger)
        {
            _titleRepository = titleRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<TitleDetailDto>>> Handle(GetAllTitleQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _titleRepository.GetAllDetailsAsync(request.QueryParams, request.IsMale, cancellationToken);
            return new ApiResponse<PaginatedResponse<TitleDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
