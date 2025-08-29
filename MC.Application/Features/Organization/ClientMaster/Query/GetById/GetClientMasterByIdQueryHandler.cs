using AutoMapper;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientMaster.Query.GetById
{
    public class GetClientMasterByIdQueryHandler : IRequestHandler<GetClientMasterByIdQuery, ClientMasterDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IClientMasterRepository _clientMasterRepository;

        public GetClientMasterByIdQueryHandler(IMapper mapper, IClientMasterRepository clientMasterRepository)
        {
            _mapper = mapper;
            _clientMasterRepository = clientMasterRepository;
        }

        public async Task<ClientMasterDetailDto> Handle(GetClientMasterByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _clientMasterRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(ClientMaster), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<ClientMasterDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
