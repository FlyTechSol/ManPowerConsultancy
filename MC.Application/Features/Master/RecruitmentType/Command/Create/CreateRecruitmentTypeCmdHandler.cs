using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Command.Create
{
    public class CreateRecruitmentTypeCmdHandler : IRequestHandler<CreateRecruitmentTypeCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;

        public CreateRecruitmentTypeCmdHandler(IMapper mapper, IRecruitmentTypeRepository recruitmentTypeRepository)
        {
            _mapper = mapper;
            _recruitmentTypeRepository = recruitmentTypeRepository;
        }

        public async Task<Guid> Handle(CreateRecruitmentTypeCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateRecruitmentTypeCmdValidator(_recruitmentTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid recruitment type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.RecruitmentType>(request);

            await _recruitmentTypeRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
