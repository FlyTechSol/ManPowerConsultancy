using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileIdQueryHandler : IRequestHandler<GetAllByUserProfileIdQuery, ApiResponse<PaginatedResponse<ExArmyDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IExArmyRepository _exArmyRepository;

        public GetAllByUserProfileIdQueryHandler(IMapper mapper, IExArmyRepository exArmyRepository)
        {
            _mapper = mapper;
            _exArmyRepository = exArmyRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<ExArmyDetailDto>>> Handle(GetAllByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _exArmyRepository.GetExArmyByUserProfileIdAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<ExArmyDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
