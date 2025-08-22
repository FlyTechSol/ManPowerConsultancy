using AutoMapper;
using FluentValidation;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Domain.Entity.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Command.Update
{
    public class UpdateRecruitmentTypeCmdHandler : IRequestHandler<UpdateRecruitmentTypeCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;
        private readonly IAppLogger<UpdateRecruitmentTypeCmdHandler> _logger;

        public UpdateRecruitmentTypeCmdHandler(IMapper mapper, IRecruitmentTypeRepository recruitmentTypeRepository, IAppLogger<UpdateRecruitmentTypeCmdHandler> logger)
        {
            _mapper = mapper;
            _recruitmentTypeRepository = recruitmentTypeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateRecruitmentTypeCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _recruitmentTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateRecruitmentTypeCmdValidator(_recruitmentTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(RecruitmentType), request.Id);
                throw new BadRequestException("Invalid recruitment type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _recruitmentTypeRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
