using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Religion.Command.Create
{
    public class CreateReligionCmdValidator : AbstractValidator<CreateReligionCmd>
    {
        private readonly IReligionRepository _religionRepository;

        public CreateReligionCmdValidator(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(CodeMustUnique)
                .WithMessage("Asset record already exists");
        }

        private Task<bool> CodeMustUnique(CreateReligionCmd command, CancellationToken token)
        {
            return _religionRepository.IsUnique(command.Code, token);
        }
    }
}
