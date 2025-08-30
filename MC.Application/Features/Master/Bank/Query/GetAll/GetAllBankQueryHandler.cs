using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetAll
{
    public class GetAllBankQueryHandler : IRequestHandler<GetAllBankQuery, ApiResponse<PaginatedResponse<BankDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;
        private readonly IAppLogger<GetAllBankQueryHandler> _logger;

        public GetAllBankQueryHandler(IMapper mapper,
            IBankRepository bankRepository,
            IAppLogger<GetAllBankQueryHandler> logger)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedResponse<BankDetailDto>>> Handle(GetAllBankQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _bankRepository.GetAllDetailsAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<BankDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
