using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Create
{
    public class CreateBranchCmdHandler : IRequestHandler<CreateBranchCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public CreateBranchCmdHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
        }

        public async Task<Guid> Handle(CreateBranchCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateBranchCmdValidator(_branchRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid branch type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Branch>(request);

            await _branchRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
