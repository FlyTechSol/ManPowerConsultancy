using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Command.Create
{
    public class CreateExArmyCmdHandler : IRequestHandler<CreateExArmyCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IExArmyRepository _exArmyRepository;

        public CreateExArmyCmdHandler(IMapper mapper, IExArmyRepository exArmyRepository)
        {
            _mapper = mapper;
            _exArmyRepository = exArmyRepository;
        }

        public async Task<Guid> Handle(CreateExArmyCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateExArmyCmdValidator(_exArmyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid ex army record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.ExArmy>(request);

            // add to database
            await _exArmyRepository.CreateExArmyAsync(recordToCreate, request.DischargeCertificateUrl, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
