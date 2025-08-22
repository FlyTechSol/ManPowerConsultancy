using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetInactiveRecordByregistrationId
{
    public class GetInactiveRecordByregistrationIdQueryHandler : IRequestHandler<GetInactiveRecordByregistrationIdQuery, List<BankAccountDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetInactiveRecordByregistrationIdQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<List<BankAccountDetailDto>> Handle(GetInactiveRecordByregistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bankAccountRepository.GetInactiveRecordByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<BankAccountDetailDto>>(response);

            // return list of DTO object
            return data;
        }
    }
}
