using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.Company.Command.Create
{
    public class CreateCompanyCmdHandler : IRequestHandler<CreateCompanyCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCmdHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(CreateCompanyCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateCompanyCmdValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid company record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Organization.Company>(request);

            await _companyRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
