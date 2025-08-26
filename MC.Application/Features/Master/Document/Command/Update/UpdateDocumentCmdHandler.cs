using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Document.Command.Update
{
    public class UpdateDocumentCmdHandler : IRequestHandler<UpdateDocumentCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly IAppLogger<UpdateDocumentCmdHandler> _logger;

        public UpdateDocumentCmdHandler(IMapper mapper, IDocumentRepository documentRepository, IAppLogger<UpdateDocumentCmdHandler> logger)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateDocumentCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _documentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateDocumentCmdValidator(_documentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Document), request.Id);
                throw new BadRequestException("Invalid document type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _documentRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
