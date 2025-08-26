using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Document.Command.Create
{
    public class CreateDocumentCmdHandler : IRequestHandler<CreateDocumentCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public CreateDocumentCmdHandler(IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }

        public async Task<Guid> Handle(CreateDocumentCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateDocumentCmdValidator(_documentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid document type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Document>(request);

            await _documentRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
