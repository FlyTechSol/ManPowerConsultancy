using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetByUserProfileId
{
    public class GetByUserProfileIdQueryHandler : IRequestHandler<GetByUserProfileIdQuery, BodyMeasurementDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public GetByUserProfileIdQueryHandler(IMapper mapper, IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _mapper = mapper;
            _bodyMeasurementRepository = bodyMeasurementRepository;
        }

        public async Task<BodyMeasurementDetailDto> Handle(GetByUserProfileIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bodyMeasurementRepository.GetByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BodyMeasurement), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<BodyMeasurementDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
