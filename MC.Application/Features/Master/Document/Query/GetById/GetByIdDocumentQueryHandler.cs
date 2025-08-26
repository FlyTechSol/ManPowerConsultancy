using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetById
{
    public class GetByIdDocumentQueryHandler : IRequestHandler<GetByIdDocumentQuery, DocumentDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public GetByIdDocumentQueryHandler(IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }

        public async Task<DocumentDetailDto> Handle(GetByIdDocumentQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Document), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<DocumentDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
