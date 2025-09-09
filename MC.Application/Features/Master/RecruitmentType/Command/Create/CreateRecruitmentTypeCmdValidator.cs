using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.RecruitmentType.Command.Create
{
    public class CreateRecruitmentTypeCmdValidator : AbstractValidator<CreateRecruitmentTypeCmd>
    {
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;

        public CreateRecruitmentTypeCmdValidator(IRecruitmentTypeRepository recruitmentTypeRepository)
        {
            _recruitmentTypeRepository = recruitmentTypeRepository;

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
            return _recruitmentTypeRepository.IsUnique(code, token);
        }
    }
}
