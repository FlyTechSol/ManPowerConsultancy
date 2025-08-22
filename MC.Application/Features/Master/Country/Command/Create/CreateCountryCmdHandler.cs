using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Country.Command.Create
{
    public class CreateCountryCmdHandler : IRequestHandler<CreateCountryCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CreateCountryCmdHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<Guid> Handle(CreateCountryCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateCountryCmdValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid country record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Country>(request);

            await _countryRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
