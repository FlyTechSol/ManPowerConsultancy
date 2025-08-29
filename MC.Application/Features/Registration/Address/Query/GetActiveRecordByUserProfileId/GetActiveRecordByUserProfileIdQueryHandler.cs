using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetActiveRecordByUserProfileId
{
    public class GetActiveRecordByUserProfileIdQueryHandler : IRequestHandler<GetActiveRecordByUserProfileIdQuery, AddressDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetActiveRecordByUserProfileIdQueryHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<AddressDetailDto> Handle(GetActiveRecordByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _addressRepository.GetActiveAddressByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Address), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<AddressDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
