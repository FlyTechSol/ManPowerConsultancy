using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Features.Master.DocumentType.Query.GetAll;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAllByPurpose
{
    public class GetAllByPurposeQueryHandler : IRequestHandler<GetAllByPurposeQuery, ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IAppLogger<GetAllByPurposeQueryHandler> _logger;

        public GetAllByPurposeQueryHandler(IMapper mapper,
            IDocumentTypeRepository documentTypeRepository,
            IAppLogger<GetAllByPurposeQueryHandler> logger)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>> Handle(GetAllByPurposeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentTypeRepository.GetDocumentsByPurposeAsync(request.QueryParams, request.Purpose, cancellationToken);
            return new ApiResponse<PaginatedResponse<DocumentTypeDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
