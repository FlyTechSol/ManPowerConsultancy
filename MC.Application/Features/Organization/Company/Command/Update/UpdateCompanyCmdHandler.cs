using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.Company.Command.Update
{
    public class UpdateCompanyCmdHandler : IRequestHandler<UpdateCompanyCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<UpdateCompanyCmdHandler> _logger;

        public UpdateCompanyCmdHandler(IMapper mapper, ICompanyRepository companyRepository, IAppLogger<UpdateCompanyCmdHandler> logger)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCompanyCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateCompanyCmdValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Company), request.Id);
                throw new BadRequestException("Invalid company record", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _companyRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
