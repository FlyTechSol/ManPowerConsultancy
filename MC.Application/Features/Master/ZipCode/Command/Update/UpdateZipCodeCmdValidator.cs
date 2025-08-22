using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.ZipCode.Command.Update;

public class UpdateZipCodeCmdValidator : AbstractValidator<UpdateZipCodeCmd>
{
    private readonly IZipCodeRepository _zipCodeRepository;
    public UpdateZipCodeCmdValidator(IZipCodeRepository zipCodeRepository)
    {
        _zipCodeRepository = zipCodeRepository;
        RuleFor(p => p.Id)
           .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(ZipcodeMustExist);

        RuleFor(p => p.Zipcode)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters")
            // Add uniqueness check for EmployeeNumber while excluding the current EmployeeNumber.
            .MustAsync((command, value, cancellationToken) => MustBeUniqueForUpdate(command.Id, value, cancellationToken))
            .WithMessage("{PropertyName} must be unique.");

        RuleFor(p => p.City)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(150).WithMessage("{PropertyName} must be fewer than 150 characters");

        RuleFor(p => p.State)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull()
           .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        RuleFor(p => p.District)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        RuleFor(p => p.Country)
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
    }
    private async Task<bool> MustBeUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
    {
        var isUnique = await _zipCodeRepository.IsUniqueForUpdate(id, value, cancellationToken);
        return isUnique;
    }
    private async Task<bool> ZipcodeMustExist(Guid id, CancellationToken cancellationToken)
    {
        var response = await _zipCodeRepository.GetByIdAsync(id, cancellationToken);
        return response != null;
    }
}
