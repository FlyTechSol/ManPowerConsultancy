using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Command.Create
{
    public class CreateZipCodeCmdHandler : IRequestHandler<CreateZipCodeCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IZipCodeRepository _zipCodeRepository;

        public CreateZipCodeCmdHandler(IMapper mapper, IZipCodeRepository zipCodeRepository)
        {
            _mapper = mapper;
            _zipCodeRepository = zipCodeRepository;
        }

        public async Task<Guid> Handle(CreateZipCodeCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateZipCodeCmdValidator(_zipCodeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid zip code", validationResult);

            // convert to domain entity object
            var locationToCreate = _mapper.Map<Domain.Entity.Master.ZipCode>(request);

            // add to database
            await _zipCodeRepository.CreateAsync(locationToCreate, cancellationToken);

            // retun record id
            return locationToCreate.Id;
        }
    }
}
