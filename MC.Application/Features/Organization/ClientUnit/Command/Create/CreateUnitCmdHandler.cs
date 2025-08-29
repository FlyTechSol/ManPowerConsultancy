using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Command.Create
{
    public class CreateUnitCmdHandler : IRequestHandler<CreateUnitCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;

        public CreateUnitCmdHandler(IMapper mapper, IUnitRepository unitRepository)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
        }

        public async Task<Guid> Handle(CreateUnitCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateUnitCmdValidator(_unitRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid client unit type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Organization.ClientUnit>(request);

            await _unitRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
