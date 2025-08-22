using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Title.Command.Create
{
    public class CreateTitleCmdValidator : AbstractValidator<CreateTitleCmd>
    {
        private readonly ITitleRepository _titleRepository;

        public CreateTitleCmdValidator(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(q => q)
                .MustAsync(TitleCodeUnique)
                .WithMessage("Title already exists");
        }

        private Task<bool> TitleCodeUnique(CreateTitleCmd command, CancellationToken token)
        {
            return _titleRepository.IsUnique(command.Code, token);
        }
    }
}
