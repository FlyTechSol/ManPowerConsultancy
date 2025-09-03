using FluentValidation;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserProfile.Command.Update
{
    public class UpdateUserProfileCmdValidator : AbstractValidator<UpdateUserProfileCmd>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UpdateUserProfileCmdValidator(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ClientMasterId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ClientUnitId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.MiddleName)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.LastName)
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.DateOfJoining)
                .NotEmpty().WithMessage("Date of Joining is required")
                .Must(date => date <= DateTime.Today)
                .WithMessage("Date of Joining cannot be in the future");

            // Aadhaar must be unique, excluding current record
            RuleFor(p => p.AadhaarNumber)
                .MustAsync((cmd, aadhaar, ct) => _userProfileRepository.IsAadhaarUniqueForUpdate(cmd.Id, aadhaar!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.AadhaarNumber))
                .WithMessage("Aadhaar number already exists");

            RuleFor(p => p.PanNo)
                .MustAsync((cmd, pan, ct) => _userProfileRepository.IsPanUniqueForUpdate(cmd.Id, pan!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.PanNo))
                .WithMessage("PAN number already exists");

            RuleFor(p => p.UanNumber)
                .MustAsync((cmd, uan, ct) => _userProfileRepository.IsUanNumberUniqueForUpdate(cmd.Id, uan!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.UanNumber))
                .WithMessage("UAN number already exists");

            RuleFor(p => p.EsicNumber)
                .MustAsync((cmd, esic, ct) => _userProfileRepository.IsEsicUniqueForUpdate(cmd.Id, esic!, ct))
                .When(p => !string.IsNullOrWhiteSpace(p.EsicNumber))
                .WithMessage("ESIC number already exists");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userProfileRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
       
    }
}
