using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.HighestEducation.Command.Create
{
    public class CreateHighestEducationCmdValidator : AbstractValidator<CreateHighestEducationCmd>
    {
        private readonly IHighestEducationRepository _highestEducationRepository;

        public CreateHighestEducationCmdValidator(IHighestEducationRepository highestEducationRepository)
        {
            _highestEducationRepository = highestEducationRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

            RuleFor(q => q)
                .MustAsync(CodeMustUnique)
                .WithMessage("Highest education record already exists");
        }

        private Task<bool> CodeMustUnique(CreateHighestEducationCmd command, CancellationToken token)
        {
            return _highestEducationRepository.IsUnique(command.Code, token);
        }
    }
}
