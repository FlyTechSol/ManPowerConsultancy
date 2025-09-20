using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.UpdateStatus
{
    public class UpdateStatusUserAssetCmdHandler : IRequestHandler<UpdateStatusUserAssetCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;

        public UpdateStatusUserAssetCmdHandler(IMapper mapper, IUserAssetRepository userAssetRepository)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
        }

        public async Task<Unit> Handle(UpdateStatusUserAssetCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _userAssetRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateStatusUserAssetCmdValidator(_userAssetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid user asset detail", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _userAssetRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
