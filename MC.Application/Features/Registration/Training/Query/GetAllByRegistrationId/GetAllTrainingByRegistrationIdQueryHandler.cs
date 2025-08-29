using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Training.Query.GetAllByRegistrationId
{
    public class GetAllTrainingByRegistrationIdQueryHandler : IRequestHandler<GetAllTrainingByRegistrationIdQuery, List<TrainingDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;

        public GetAllTrainingByRegistrationIdQueryHandler(IMapper mapper, ITrainingRepository trainingRepository)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
        }

        public async Task<List<TrainingDetailDto>> Handle(GetAllTrainingByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _trainingRepository.GetAllTrainingByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Training), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<List<TrainingDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
