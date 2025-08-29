using FluentValidation;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.ClientMaster.Command.Create
{
    public class CreateClientMasterCmdValidator : AbstractValidator<CreateClientMasterCmd>
    {
        private readonly IClientMasterRepository _clientMasterRepository;

        public CreateClientMasterCmdValidator(IClientMasterRepository clientMasterRepository)
        {
            _clientMasterRepository = clientMasterRepository;

            RuleFor(p => p.ClientName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.ProjectLocation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("Client master record already exists");
        }

        private Task<bool> RecordMustUnique(CreateClientMasterCmd command, CancellationToken token)
        {
            return _clientMasterRepository.IsUnique(command.CompanyId, command.ClientName, token);
        }
    }
}
