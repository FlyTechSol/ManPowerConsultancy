using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAll
{
    public class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IAppLogger<GetAllDocumentTypeQueryHandler> _logger;

        public GetAllDocumentTypeQueryHandler(IMapper mapper,
            IDocumentTypeRepository documentTypeRepository,
            IAppLogger<GetAllDocumentTypeQueryHandler> logger)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentTypeRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);
            return new ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
