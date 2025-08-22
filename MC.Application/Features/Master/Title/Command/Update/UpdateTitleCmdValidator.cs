using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Title.Command.Update;

public class UpdateTitleCmdValidator : AbstractValidator<UpdateTitleCmd>
{
    private readonly ITitleRepository _titleRepository;

    public UpdateTitleCmdValidator(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(TitleMustExist);

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
            .MustAsync((command, value, cancellationToken) => MustBeUniqueForUpdate(command.Id, value, cancellationToken))
            .WithMessage("{PropertyName} must be unique.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");
    }
    private async Task<bool> MustBeUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
    {
        var isUnique = await _titleRepository.IsUniqueForUpdate(id, value, cancellationToken);
        return isUnique;
    }
    private async Task<bool> TitleMustExist(Guid id, CancellationToken cancellationToken)
    {
        var title = await _titleRepository.GetByIdAsync(id, cancellationToken);
        return title != null;
    }
}
