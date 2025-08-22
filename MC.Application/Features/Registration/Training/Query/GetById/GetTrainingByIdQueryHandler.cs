using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Training.Query.GetById
{
    public class GetTrainingByIdQueryHandler : IRequestHandler<GetTrainingByIdQuery, TrainingDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;

        public GetTrainingByIdQueryHandler(IMapper mapper, ITrainingRepository trainingRepository)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
        }

        public async Task<TrainingDetailDto> Handle(GetTrainingByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _trainingRepository.GetTrainingByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Training), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<TrainingDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
