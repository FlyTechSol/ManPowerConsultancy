using FluentValidation;
using MC.Application.Contracts.Persistence.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Master.Gender.Command.Create;

public class CreateGenderCmdValidator : AbstractValidator<CreateGenderCmd>
{
    private readonly IGenderRepository _genderRepository;

    public CreateGenderCmdValidator(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

        RuleFor(p => p.Decode)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(q => q)
            .MustAsync(CodeMustUnique)
            .WithMessage("Gender already exists");
    }

    private Task<bool> CodeMustUnique(CreateGenderCmd command, CancellationToken token)
    {
        return _genderRepository.IsUnique(command.Code, token);
    }
}
