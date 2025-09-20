using FluentValidation;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Features.Registration.UserDocument.Command.Create
{
    public class CreateUserDocCmdValidator : AbstractValidator<CreateUserDocCmd>
    {
        private readonly IUserDocumentRepository _userDocumentRepository;

        public CreateUserDocCmdValidator(IUserDocumentRepository userDocumentRepository)
        {
            _userDocumentRepository = userDocumentRepository;

            RuleFor(p => p.UserProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.DocumentTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required");
                       
        }
    }
}
