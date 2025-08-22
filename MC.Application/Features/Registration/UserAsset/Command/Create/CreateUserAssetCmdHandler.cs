using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Command.Create
{
    public class CreateUserAssetCmdHandler : IRequestHandler<CreateUserAssetCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserAssetRepository _userAssetRepository;

        public CreateUserAssetCmdHandler(IMapper mapper, IUserAssetRepository userAssetRepository)
        {
            _mapper = mapper;
            _userAssetRepository = userAssetRepository;
        }

        public async Task<Guid> Handle(CreateUserAssetCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateUserAssetCmdValidator(_userAssetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid user asset record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.UserAsset>(request);

            // add to database
            await _userAssetRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
