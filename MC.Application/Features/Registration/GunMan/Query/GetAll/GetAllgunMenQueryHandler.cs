using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Query.GetAll
{
    public class GetAllgunMenQueryHandler : IRequestHandler<GetAllgunMenQuery, ApiResponse<PaginatedResponse<GunManDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IGunManRepository _gunManRepository;

        public GetAllgunMenQueryHandler(IMapper mapper, IGunManRepository gunManRepository)
        {
            _mapper = mapper;
            _gunManRepository = gunManRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<GunManDetailDto>>> Handle(GetAllgunMenQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _gunManRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<GunManDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
