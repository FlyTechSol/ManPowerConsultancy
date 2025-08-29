using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetById
{
    public class GetByIdDocumentTypeQueryHandler : IRequestHandler<GetByIdDocumentTypeQuery, DocumentTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public GetByIdDocumentTypeQueryHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<DocumentTypeDetailDto> Handle(GetByIdDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _documentTypeRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(DocumentType), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<DocumentTypeDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
