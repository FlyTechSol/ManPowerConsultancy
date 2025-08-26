using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetActiveRecordByregistrationId
{
    public class GetActiveRecordByregistrationIdQueryHandler : IRequestHandler<GetActiveRecordByregistrationIdQuery, BankAccountDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetActiveRecordByregistrationIdQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<BankAccountDetailDto> Handle(GetActiveRecordByregistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bankAccountRepository.GetActiveRecordByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BankAccount), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<BankAccountDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
