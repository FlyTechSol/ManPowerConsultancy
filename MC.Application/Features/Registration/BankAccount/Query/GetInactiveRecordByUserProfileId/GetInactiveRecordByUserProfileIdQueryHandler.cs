using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByUserProfileId
{
    public class GetInactiveRecordByUserProfileIdQueryHandler : IRequestHandler<GetInactiveRecordByUserProfileIdQuery, List<BankAccountDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetInactiveRecordByUserProfileIdQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<List<BankAccountDetailDto>> Handle(GetInactiveRecordByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bankAccountRepository.GetInactiveRecordByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<BankAccountDetailDto>>(response);

            // return list of DTO object
            return data;
        }
    }
}
