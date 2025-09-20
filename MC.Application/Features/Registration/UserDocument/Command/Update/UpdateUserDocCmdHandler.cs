using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Command.Update
{
    public class UpdateUserDocCmdHandler : IRequestHandler<UpdateUserDocCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserDocumentRepository _userDocumentRepository;

        public UpdateUserDocCmdHandler(IMapper mapper, IUserDocumentRepository userDocumentRepository)
        {
            _mapper = mapper;
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<Unit> Handle(UpdateUserDocCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _userDocumentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateUserDocCmdValidator(_userDocumentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid user document detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _userDocumentRepository.UpdateUserDocumentAsync(recordToUpdate, request.FilePath, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
