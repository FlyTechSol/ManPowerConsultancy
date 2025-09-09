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
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _highestEducationRepository.IsUnique(code, token);
        }
    }
}
