using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Bank.Command.Update;

public class UpdateBankCmdValidator : AbstractValidator<UpdateBankCmd>
{
    private readonly IBankRepository _bankRepository;

    public UpdateBankCmdValidator(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(RecordMustExist);

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
             .MustAsync((command, code, cancellationToken) =>
                DecodeMustBeUniqueForUpdate(command.Id, code, cancellationToken))
            .WithMessage("{PropertyName} must be unique.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
    }

    private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string decode, CancellationToken cancellationToken)
    {
        var isUnique = await _bankRepository.IsUniqueForUpdate(id, decode, cancellationToken);
        return isUnique;
    }

    private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
    {
        var record = await _bankRepository.GetByIdAsync(id, cancellationToken);
        return record != null;
    }
}
