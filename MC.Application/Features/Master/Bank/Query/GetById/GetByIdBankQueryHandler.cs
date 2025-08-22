using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Bank.Query.GetById
{
    public class GetByIdBankQueryHandler : IRequestHandler<GetByIdBankQuery, BankDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;

        public GetByIdBankQueryHandler(IMapper mapper, IBankRepository bankRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<BankDetailDto> Handle(GetByIdBankQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _bankRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Bank), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<BankDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
