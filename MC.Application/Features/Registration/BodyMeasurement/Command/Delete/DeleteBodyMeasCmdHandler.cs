using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BodyMeasurement.Command.Delete
{
    public class DeleteBodyMeasCmdHandler : IRequestHandler<DeleteBodyMeasCmd, Unit>
    {
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;

        public DeleteBodyMeasCmdHandler(IBodyMeasurementRepository bodyMeasurementRepository)
        {
            _bodyMeasurementRepository = bodyMeasurementRepository;
        }

        public async Task<Unit> Handle(DeleteBodyMeasCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var response = await _bodyMeasurementRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.BodyMeasurement), request.Id);

            // remove from database
            await _bodyMeasurementRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
