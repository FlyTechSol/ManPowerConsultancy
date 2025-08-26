using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAll
{
    public class GetAllDocumentQueryHandler : IRequestHandler<GetAllDocumentQuery, List<DocumentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly IAppLogger<GetAllDocumentQueryHandler> _logger;

        public GetAllDocumentQueryHandler(IMapper mapper,
            IDocumentRepository documentRepository,
            IAppLogger<GetAllDocumentQueryHandler> logger)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public async Task<List<DocumentDto>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Document were retrieved successfully");
            return data;
        }
    }
}
