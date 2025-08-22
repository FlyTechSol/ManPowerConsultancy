using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetAll
{
    public class GetAllBankQueryHandler : IRequestHandler<GetAllBankQuery, List<BankDto>>
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

        public async Task<List<BankDto>> Handle(GetAllBankQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _bankRepository.GetAllDetailsAsync(cancellationToken);

            // convert data objects to DTO objects
            var data = _mapper.Map<List<BankDto>>(record);

            // return list of DTO object
            _logger.LogInformation("Bank were retrieved successfully");
            return data;
        }
    }
}
