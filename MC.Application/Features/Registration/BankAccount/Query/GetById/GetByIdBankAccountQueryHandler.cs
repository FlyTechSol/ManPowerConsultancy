using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetById
{
    public class GetByIdBankAccountQueryHandler : IRequestHandler<GetByIdBankAccountQuery, BankAccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetByIdBankAccountQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<BankAccountDto> Handle(GetByIdBankAccountQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var bankDetail = await _bankAccountRepository.GetDetailByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (bankDetail == null)
                throw new NotFoundException(nameof(bankDetail), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<BankAccountDto>(bankDetail);

            // return DTO object
            return data;
        }
    }
}
