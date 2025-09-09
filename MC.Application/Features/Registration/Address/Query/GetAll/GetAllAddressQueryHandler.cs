using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Query.GetAll
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, ApiResponse<PaginatedResponse<AddressDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressQueryHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<AddressDetailDto>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _addressRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<AddressDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
