using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Create
{
    public class CreatePoliceVeriCmdHandler : IRequestHandler<CreatePoliceVeriCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public CreatePoliceVeriCmdHandler(IMapper mapper, IPoliceVerificationRepository policeVerificationRepository)
        {
            _mapper = mapper;
            _policeVerificationRepository = policeVerificationRepository;
        }

        public async Task<Guid> Handle(CreatePoliceVeriCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreatePoliceVeriCmdValidator(_policeVerificationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid police verification record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.PoliceVerification>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _policeVerificationRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
