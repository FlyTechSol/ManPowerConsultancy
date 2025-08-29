using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByUserProfileId
{
    public class GetActiveRecordByUserProfileIdQueryHandler : IRequestHandler<GetActiveRecordByUserProfileIdQuery, BankAccountDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetActiveRecordByUserProfileIdQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<BankAccountDetailDto> Handle(GetActiveRecordByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bankAccountRepository.GetActiveRecordByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BankAccount), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<BankAccountDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
