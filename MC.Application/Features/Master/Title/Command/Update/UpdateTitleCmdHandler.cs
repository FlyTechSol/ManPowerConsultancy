using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Title.Command.Update
{
   public class UpdateTitleCmdHandler : IRequestHandler<UpdateTitleCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly IAppLogger<UpdateTitleCmdHandler> _logger;

        public UpdateTitleCmdHandler(IMapper mapper, ITitleRepository titleRepository, IAppLogger<UpdateTitleCmdHandler> logger)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTitleCmd request, CancellationToken cancellationToken)
        {
            var titleUpdateRequest = await _titleRepository.GetByIdAsync(request.Id, cancellationToken);

            if (titleUpdateRequest is null)
                throw new NotFoundException(nameof(titleUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateTitleCmdValidator(_titleRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Title), request.Id);
                throw new BadRequestException("Invalid Title", validationResult);
            }

            // convert to domain entity object
            var titleToUpdate = _mapper.Map(request, titleUpdateRequest);

            // add to database
            await _titleRepository.UpdateAsync(titleToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
