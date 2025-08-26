using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Create
{
    public class CreateResignationCmdHandler : IRequestHandler<CreateResignationCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IResignationRepository _resignationRepository;

        public CreateResignationCmdHandler(IMapper mapper, IResignationRepository resignationRepository)
        {
            _mapper = mapper;
            _resignationRepository = resignationRepository;
        }

        public async Task<Guid> Handle(CreateResignationCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateResignationCmdValidator(_resignationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid resignation record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.Resignation>(request);
             // add to database
            await _resignationRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
