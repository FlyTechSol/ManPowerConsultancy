using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserDocument.Command.Update
{
    public class UpdateUserDocCmdValidator : AbstractValidator<UpdateUserDocCmd>
    {
        private readonly IUserDocumentRepository _userDocumentRepository;

        public UpdateUserDocCmdValidator(IUserDocumentRepository userDocumentRepository)
        {
            _userDocumentRepository = userDocumentRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.UserProfileId)
                 .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.DocumentTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userDocumentRepository.GetByIdAsync(id, cancellationToken);
            return response != null;
        }
    }
}
