using AutoMapper;
using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Command.Create
{
    public class CreateUserProfileCmdHandler : IRequestHandler<CreateUserProfileCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileCmdHandler(IMapper mapper, IUserProfileRepository userProfileRepository)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<Guid> Handle(CreateUserProfileCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserProfileCmdValidator(_userProfileRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid user profile data", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<MC.Domain.Entity.Registration.UserProfile>(request);

            await _userProfileRepository.CreateUserProfileAsync(recordToCreate, request.ProfilePicture, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
