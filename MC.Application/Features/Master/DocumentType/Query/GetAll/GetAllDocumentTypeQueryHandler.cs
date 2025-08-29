using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAll
{
    public class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, List<DocumentTypeDto>>
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

        public async Task<List<DocumentTypeDto>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentTypeRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentTypeDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Document type were retrieved successfully");
            return data;
        }
    }
}
