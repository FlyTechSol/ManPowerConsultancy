using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.GetAll
{
    public class GetAllBankAccountQueryHandler : IRequestHandler<GetAllBankAccountQuery, ApiResponse<PaginatedResponse<BankAccountDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetAllBankAccountQueryHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<BankAccountDetailDto>>> Handle(GetAllBankAccountQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _bankAccountRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<BankAccountDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
