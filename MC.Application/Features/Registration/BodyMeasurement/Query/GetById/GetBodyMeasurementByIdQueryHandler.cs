using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Query.GetById
{
    public class GetBodyMeasurementByIdQueryHandler : IRequestHandler<GetBodyMeasurementByIdQuery, BodyMeasurementDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public GetBodyMeasurementByIdQueryHandler(IMapper mapper, IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _mapper = mapper;
            _bodyMeasurementRepository = bodyMeasurementRepository;
        }

        public async Task<BodyMeasurementDetailDto> Handle(GetBodyMeasurementByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _bodyMeasurementRepository.GetBodyMeasurementByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BodyMeasurement), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<BodyMeasurementDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
