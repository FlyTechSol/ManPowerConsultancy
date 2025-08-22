using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Gender.Command.Update;

public class UpdateGenderCmdValidator : AbstractValidator<UpdateGenderCmd>
{
    private readonly IGenderRepository _genderRepository;

    public UpdateGenderCmdValidator(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(GenderMustExist);

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
             .MustAsync((command, code, cancellationToken) =>
                DecodeMustBeUniqueForUpdate(command.Id, code, cancellationToken))
            .WithMessage("{PropertyName} must be unique.");

        RuleFor(p => p.Decode)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
    }

    private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string decode, CancellationToken cancellationToken)
    {
        var isUnique = await _genderRepository.IsUniqueForUpdate(id, decode, cancellationToken);
        return isUnique;
    }

    private async Task<bool> GenderMustExist(Guid id, CancellationToken cancellationToken)
    {
        var record = await _genderRepository.GetByIdAsync(id, cancellationToken);
        return record != null;
    }
}

