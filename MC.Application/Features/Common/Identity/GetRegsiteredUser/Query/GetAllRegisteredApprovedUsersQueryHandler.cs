using AutoMapper;
using MC.Application.Contracts.Identity;
using MC.Application.Model.Identity.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MediatR;

namespace MC.Application.Features.Common.Identity.GetRegsiteredUser.Query
{
    public class GetAllRegisteredApprovedUsersQueryHandler : IRequestHandler<GetAllRegisteredApprovedUsersQuery, ApiResponse<PaginatedResponse<RegsiteredApprovedUserDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public GetAllRegisteredApprovedUsersQueryHandler(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<ApiResponse<PaginatedResponse<RegsiteredApprovedUserDto>>> Handle(GetAllRegisteredApprovedUsersQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _authService.GetAllRegisteredApprovedUsersAsync(request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<RegsiteredApprovedUserDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
