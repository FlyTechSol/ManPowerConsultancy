using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Features.Master.DocumentType.Query.GetAll;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAllByPurpose
{
    public class GetAllByPurposeQueryHandler : IRequestHandler<GetAllByPurposeQuery, List<DocumentTypeDto>>
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

        public async Task<List<DocumentTypeDto>> Handle(GetAllByPurposeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentTypeRepository.GetDocumentsByPurposeAsync(request.purpose, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentTypeDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Document type were retrieved successfully");
            return data;
        }
    }
}
