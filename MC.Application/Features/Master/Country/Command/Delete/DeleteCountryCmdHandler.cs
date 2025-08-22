using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Country.Command.Delete
{
    public class DeleteCountryCmdHandler : IRequestHandler<DeleteCountryCmd, Unit>
    {
        private readonly ICountryRepository _countryRepository;

        public DeleteCountryCmdHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Unit> Handle(DeleteCountryCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Country), request.Id);

            // remove from database
            await _countryRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
