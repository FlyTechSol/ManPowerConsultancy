using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Command.Create
{
    public class CreateUserDocCmdHandler : IRequestHandler<CreateUserDocCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserDocumentRepository _userDocumentRepository;

        public CreateUserDocCmdHandler(IMapper mapper, IUserDocumentRepository userDocumentRepository)
        {
            _mapper = mapper;
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<Guid> Handle(CreateUserDocCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateUserDocCmdValidator(_userDocumentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid user document record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.UserDocument>(request);

            // add to database
            await _userDocumentRepository.CreateUserDocumentAsync(recordToCreate, request.FilePath, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
