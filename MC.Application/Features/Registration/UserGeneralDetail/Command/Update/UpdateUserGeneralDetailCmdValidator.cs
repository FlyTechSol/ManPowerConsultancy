using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Update
{
   public class UpdateUserGeneralDetailCmdValidator : AbstractValidator<UpdateUserGeneralDetailCmd>
    {
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public UpdateUserGeneralDetailCmdValidator(IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _userGeneralDetailRepository = userGeneralDetailRepository;

            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(RecordMustExist);

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
        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userGeneralDetailRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
