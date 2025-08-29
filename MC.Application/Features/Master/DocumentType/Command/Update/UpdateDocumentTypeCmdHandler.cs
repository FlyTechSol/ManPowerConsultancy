using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Update
{
    public class UpdateDocumentTypeCmdHandler : IRequestHandler<UpdateDocumentTypeCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IAppLogger<UpdateDocumentTypeCmdHandler> _logger;

        public UpdateDocumentTypeCmdHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository, IAppLogger<UpdateDocumentTypeCmdHandler> logger)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateDocumentTypeCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _documentTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateDocumentTypeCmdValidator(_documentTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(DocumentType), request.Id);
                throw new BadRequestException("Invalid document type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _documentTypeRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
