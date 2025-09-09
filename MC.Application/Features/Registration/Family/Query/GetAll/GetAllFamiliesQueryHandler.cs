using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetAll
{
    public class GetAllFamiliesQueryHandler : IRequestHandler<GetAllFamiliesQuery, ApiResponse<PaginatedResponse<FamilyDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;

        public GetAllFamiliesQueryHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<FamilyDetailDto>>> Handle(GetAllFamiliesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _familyRepository.GetAllFamilyDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<FamilyDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
