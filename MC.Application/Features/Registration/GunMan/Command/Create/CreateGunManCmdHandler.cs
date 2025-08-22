using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Command.Create
{
    public class CreateGunManCmdHandler : IRequestHandler<CreateGunManCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGunManRepository _gunManRepository;

        public CreateGunManCmdHandler(IMapper mapper, IGunManRepository gunManRepository)
        {
            _mapper = mapper;
            _gunManRepository = gunManRepository;
        }

        public async Task<Guid> Handle(CreateGunManCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateGunManCmdValidator(_gunManRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid gun man record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.GunMan>(request);

            // add to database
            await _gunManRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
