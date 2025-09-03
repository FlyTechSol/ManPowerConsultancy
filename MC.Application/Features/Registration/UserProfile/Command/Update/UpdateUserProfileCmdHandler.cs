using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Command.Update
{
    public class UpdateUserProfileCmdHandler : IRequestHandler<UpdateUserProfileCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IAppLogger<UpdateUserProfileCmdHandler> _logger;

        public UpdateUserProfileCmdHandler(IMapper mapper, IUserProfileRepository userProfileRepository, IAppLogger<UpdateUserProfileCmdHandler> logger)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserProfileCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _userProfileRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateUserProfileCmdValidator(_userProfileRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.UserProfile), request.Id);
                throw new BadRequestException("Invalid user profile detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _userProfileRepository.UpdateUserProfileAsync(recordToUpdate, request.ProfilePicture, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
