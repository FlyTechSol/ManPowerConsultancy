using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Features.Master.Document.Query.GetAllAgeProof;
using MC.Application.ModelDto.Master.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Master.Document.Query.GetAllAddressProof
{
    public class GetAllAddressProofQueryHandler : IRequestHandler<GetAllAddressProofQuery, List<DocumentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetAllAddressProofQueryHandler(IMapper mapper,
            IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentDto>> Handle(GetAllAddressProofQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentRepository.GetAddressProofDocumentsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DocumentDto>>(record);

            return data;
        }
    }
}
