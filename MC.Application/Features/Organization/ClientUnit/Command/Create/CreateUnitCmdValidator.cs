using FluentValidation;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.ClientUnit.Command.Create
{
    public class CreateUnitCmdValidator : AbstractValidator<CreateUnitCmd>
    {
        private readonly IUnitRepository _unitRepository;

        public CreateUnitCmdValidator(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;

            RuleFor(p => p.ClientMasterId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.UnitName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("Client unit record already exists");
        }

        private Task<bool> RecordMustUnique(CreateUnitCmd command, CancellationToken token)
        {
            return _unitRepository.IsUnique(command.ClientMasterId, command.UnitName, token);
        }
    }
}
