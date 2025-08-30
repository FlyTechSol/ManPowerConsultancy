using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Designation.Command.Create
{
    public class CreateDesignationCmdValidator : AbstractValidator<CreateDesignationCmd>
    {
        private readonly IDesignationRepository _designationRepository;

        public CreateDesignationCmdValidator(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(q => q)
                .MustAsync(RecordMustUnique)
                .WithMessage("Designation record already exists");
        }

        private Task<bool> RecordMustUnique(CreateDesignationCmd command, CancellationToken token)
        {
            return _designationRepository.IsUnique(command.Code, token);
        }
    }
}
