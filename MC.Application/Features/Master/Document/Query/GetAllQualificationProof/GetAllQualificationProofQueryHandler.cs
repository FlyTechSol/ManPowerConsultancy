using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllQualificationProof
{
    public class GetAllQualificationProofQueryHandler : IRequestHandler<GetAllQualificationProofQuery, List<DocumentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetAllQualificationProofQueryHandler(IMapper mapper,
            IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentDto>> Handle(GetAllQualificationProofQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentRepository.GetQualificationProofDocumentsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentDto>>(record);

            return data;
        }
    }
}
