using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllIdentityProof
{
    public class GetAllIdentityProofQueryHandler : IRequestHandler<GetAllIdentityProofQuery, List<DocumentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetAllIdentityProofQueryHandler(IMapper mapper,
            IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentDto>> Handle(GetAllIdentityProofQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentRepository.GetIdentityProofDocumentsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentDto>>(record);

            return data;
        }
    }
}
