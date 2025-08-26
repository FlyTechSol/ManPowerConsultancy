using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Create
{
    public class CreateUserGeneralDetailCmdHandler : IRequestHandler<CreateUserGeneralDetailCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public CreateUserGeneralDetailCmdHandler(IMapper mapper, IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _mapper = mapper;
            _userGeneralDetailRepository = userGeneralDetailRepository;
        }

        public async Task<Guid> Handle(CreateUserGeneralDetailCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateUserGeneralDetailCmdValidator(_userGeneralDetailRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid user general detail record", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.UserGeneralDetail>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _userGeneralDetailRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
