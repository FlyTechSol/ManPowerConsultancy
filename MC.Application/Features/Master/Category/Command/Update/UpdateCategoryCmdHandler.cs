using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Category.Command.Update
{
    public class UpdateCategoryCmdHandler : IRequestHandler<UpdateCategoryCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<UpdateCategoryCmdHandler> _logger;

        public UpdateCategoryCmdHandler(IMapper mapper, ICategoryRepository categoryRepository, IAppLogger<UpdateCategoryCmdHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateCategoryCmdValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Category), request.Id);
                throw new BadRequestException("Invalid ctageory record", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _categoryRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
