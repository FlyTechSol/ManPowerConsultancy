using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetInactiveRecordByUserProfileId
{
    public class GetInactiveRecordByUserProfileIdQueryHandler : IRequestHandler<GetInactiveRecordByUserProfileIdQuery, List<AddressDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetInactiveRecordByUserProfileIdQueryHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressDetailDto>> Handle(GetInactiveRecordByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _addressRepository.GetInactiveAddressByUserProfileIdAsync(request.UseerProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Address), request.UseerProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<AddressDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
