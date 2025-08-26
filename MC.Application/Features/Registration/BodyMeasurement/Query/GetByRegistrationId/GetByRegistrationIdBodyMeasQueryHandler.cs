using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetByRegistrationId
{
    public class GetByRegistrationIdBodyMeasQueryHandler : IRequestHandler<GetByRegistrationIdBodyMeasQuery, BodyMeasurementDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public GetByRegistrationIdBodyMeasQueryHandler(IMapper mapper, IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _mapper = mapper;
            _bodyMeasurementRepository = bodyMeasurementRepository;
        }

        public async Task<BodyMeasurementDetailDto> Handle(GetByRegistrationIdBodyMeasQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bodyMeasurementRepository.GetByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BodyMeasurement), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<BodyMeasurementDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
