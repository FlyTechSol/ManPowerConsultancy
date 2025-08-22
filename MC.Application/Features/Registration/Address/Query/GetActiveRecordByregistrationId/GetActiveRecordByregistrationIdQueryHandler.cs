using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetActiveRecordByregistrationId
{
    public class GetActiveRecordByregistrationIdQueryHandler : IRequestHandler<GetActiveRecordByregistrationIdQuery, AddressDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetActiveRecordByregistrationIdQueryHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<AddressDetailDto> Handle(GetActiveRecordByregistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _addressRepository.GetActiveAddressByUserIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Address), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<AddressDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
