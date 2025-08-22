using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.Features.Registration.ExArmy.Command.Update;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Command.Update
{
    public class UpdateGunManCmdHandler : IRequestHandler<UpdateGunManCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGunManRepository _gunManRepository;
        private readonly IAppLogger<UpdateGunManCmdHandler> _logger;

        public UpdateGunManCmdHandler(IMapper mapper, IGunManRepository gunManRepository, IAppLogger<UpdateGunManCmdHandler> logger)
        {
            _mapper = mapper;
            _gunManRepository = gunManRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateGunManCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _gunManRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateGunManCmdValidator(_gunManRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.GunMan), request.Id);
                throw new BadRequestException("Invalid gun man detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _gunManRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
