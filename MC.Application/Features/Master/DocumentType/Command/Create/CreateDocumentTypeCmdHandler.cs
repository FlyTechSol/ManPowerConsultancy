using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Create
{
    public class CreateDocumentTypeCmdHandler : IRequestHandler<CreateDocumentTypeCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public CreateDocumentTypeCmdHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<Guid> Handle(CreateDocumentTypeCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateDocumentTypeCmdValidator(_documentTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid document type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.DocumentType>(request);

            await _documentTypeRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
