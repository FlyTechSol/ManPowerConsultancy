using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Command.Update
{
    public class UpdateCasteCategoryCmdHandler : IRequestHandler<UpdateCasteCategoryCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICasteCategoryRepository _casteCategoryRepository;
        private readonly IAppLogger<UpdateCasteCategoryCmdHandler> _logger;

        public UpdateCasteCategoryCmdHandler(IMapper mapper, ICasteCategoryRepository casteCategoryRepository, IAppLogger<UpdateCasteCategoryCmdHandler> logger)
        {
            _mapper = mapper;
            _casteCategoryRepository = casteCategoryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCasteCategoryCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _casteCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateCasteCategoryCmdValidator(_casteCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(CasteCategory), request.Id);
                throw new BadRequestException("Invalid caste category", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _casteCategoryRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
