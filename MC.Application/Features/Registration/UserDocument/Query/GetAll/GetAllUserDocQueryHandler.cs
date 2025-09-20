using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Query.GetAll
{
    public class GetAllUserDocQueryHandler : IRequestHandler<GetAllUserDocQuery, ApiResponse<PaginatedResponse<UserDocumentDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserDocumentRepository _userDocumentRepository;

        public GetAllUserDocQueryHandler(IMapper mapper, IUserDocumentRepository userDocumentRepository)
        {
            _mapper = mapper;
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<UserDocumentDetailDto>>> Handle(GetAllUserDocQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _userDocumentRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<UserDocumentDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
