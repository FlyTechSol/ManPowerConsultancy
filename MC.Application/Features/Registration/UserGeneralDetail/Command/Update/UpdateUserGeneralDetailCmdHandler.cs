using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Update
{
    public class UpdateUserGeneralDetailCmdHandler : IRequestHandler<UpdateUserGeneralDetailCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;
        private readonly IAppLogger<UpdateUserGeneralDetailCmdHandler> _logger;

        public UpdateUserGeneralDetailCmdHandler(IMapper mapper, IUserGeneralDetailRepository userGeneralDetailRepository, IAppLogger<UpdateUserGeneralDetailCmdHandler> logger)
        {
            _mapper = mapper;
            _userGeneralDetailRepository = userGeneralDetailRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserGeneralDetailCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _userGeneralDetailRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateUserGeneralDetailCmdValidator(_userGeneralDetailRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.UserGeneralDetail), request.Id);
                throw new BadRequestException("Invalid user general detail detail", validationResult);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _userGeneralDetailRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
