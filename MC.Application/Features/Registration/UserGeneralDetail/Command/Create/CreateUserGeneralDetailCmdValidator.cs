using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Create
{
    public class CreateUserGeneralDetailCmdValidator : AbstractValidator<CreateUserGeneralDetailCmd>
    {
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public CreateUserGeneralDetailCmdValidator(IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _userGeneralDetailRepository = userGeneralDetailRepository;

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.FatherName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.MotherName)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.SpouseName)
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.IdentityMarks)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

        }
    }
}
