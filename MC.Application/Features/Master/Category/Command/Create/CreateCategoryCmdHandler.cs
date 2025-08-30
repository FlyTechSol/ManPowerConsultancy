using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Category.Command.Create
{
    public class CreateCategoryCmdHandler : IRequestHandler<CreateCategoryCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCmdHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCmdValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid category record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Category>(request);

            await _categoryRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
