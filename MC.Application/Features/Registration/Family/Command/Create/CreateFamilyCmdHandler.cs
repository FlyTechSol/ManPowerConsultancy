using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Family.Command.Create
{
    public class CreateFamilyCmdHandler : IRequestHandler<CreateFamilyCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;

        public CreateFamilyCmdHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<Guid> Handle(CreateFamilyCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateFamilyCmdValidator(_familyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid family record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Family>(request);

            // add to database
            await _familyRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
