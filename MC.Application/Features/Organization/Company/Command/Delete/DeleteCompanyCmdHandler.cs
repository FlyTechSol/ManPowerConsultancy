using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Organization.Company.Command.Delete
{
    public class DeleteCompanyCmdHandler : IRequestHandler<DeleteCompanyCmd, Unit>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCmdHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _companyRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(Company), request.Id);

            // remove from database
            await _companyRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
