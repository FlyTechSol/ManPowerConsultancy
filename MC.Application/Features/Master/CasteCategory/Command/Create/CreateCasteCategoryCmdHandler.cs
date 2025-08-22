using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Command.Create
{
    public class CreateCasteCategoryCmdHandler : IRequestHandler<CreateCasteCategoryCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICasteCategoryRepository _casteCategoryRepository;

        public CreateCasteCategoryCmdHandler(IMapper mapper, ICasteCategoryRepository casteCategoryRepository)
        {
            _mapper = mapper;
            _casteCategoryRepository = casteCategoryRepository;
        }

        public async Task<Guid> Handle(CreateCasteCategoryCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateCasteCategoryCmdValidator(_casteCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid caste category", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.CasteCategory>(request);

            await _casteCategoryRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
