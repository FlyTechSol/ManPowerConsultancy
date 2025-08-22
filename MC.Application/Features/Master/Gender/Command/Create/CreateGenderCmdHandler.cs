using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Gender.Command.Create
{
    public class CreateGenderCmdHandler : IRequestHandler<CreateGenderCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;

        public CreateGenderCmdHandler(IMapper mapper, IGenderRepository genderRepository)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
        }

        public async Task<Guid> Handle(CreateGenderCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateGenderCmdValidator(_genderRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid gender type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Gender>(request);

            await _genderRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
