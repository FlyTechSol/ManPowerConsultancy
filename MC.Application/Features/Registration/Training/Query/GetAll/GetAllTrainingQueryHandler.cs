using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Training.Query.GetAll
{
    public class GetAllTrainingQueryHandler : IRequestHandler<GetAllTrainingQuery, ApiResponse<PaginatedResponse<TrainingDetailDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;

        public GetAllTrainingQueryHandler(IMapper mapper, ITrainingRepository trainingRepository)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
        }

        public async Task<ApiResponse<PaginatedResponse<TrainingDetailDto>>> Handle(GetAllTrainingQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _trainingRepository.GetAllDetailsAsync(request.UserProfileId, request.QueryParams, cancellationToken);

            return new ApiResponse<PaginatedResponse<TrainingDetailDto>>
            {
                Status = 200,
                Message = "Success",
                ResData = record
            };
        }
    }
}
