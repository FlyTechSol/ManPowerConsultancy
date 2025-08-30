using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Designation.Command.Create
{
    public class CreateDesignationCmdHandler : IRequestHandler<CreateDesignationCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IDesignationRepository _designationRepository;

        public CreateDesignationCmdHandler(IMapper mapper, IDesignationRepository designationRepository)
        {
            _mapper = mapper;
            _designationRepository = designationRepository;
        }

        public async Task<Guid> Handle(CreateDesignationCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateDesignationCmdValidator(_designationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid designation record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Designation>(request);

            await _designationRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
