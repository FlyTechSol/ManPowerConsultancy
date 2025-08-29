using FluentValidation;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.ClientMaster.Command.Update
{
    public class UpdateClientMasterCmdValidator : AbstractValidator<UpdateClientMasterCmd>
    {
        private readonly IClientMasterRepository _clientMasterRepository;

        public UpdateClientMasterCmdValidator(IClientMasterRepository clientMasterRepository)
        {
            _clientMasterRepository = clientMasterRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.ClientName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .MustAsync(BeUniqueClientNameForCompany)
                .WithMessage("Client name must be unique within the same company.");

            RuleFor(p => p.ProjectLocation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        private async Task<bool> BeUniqueClientNameForCompany(UpdateClientMasterCmd cmd, string clientName, CancellationToken cancellationToken)
        {
            return await _clientMasterRepository.IsUniqueForUpdate(cmd.Id, cmd.CompanyId, clientName, cancellationToken);
        }
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _clientMasterRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
