using FluentValidation;
using MC.Application.Contracts.Persistence.Master;
using MC.Domain.Entity.Enum.Common;

namespace MC.Application.Features.Master.DocumentType.Command.Create
{
   public class CreateDocumentTypeCmdValidator : AbstractValidator<CreateDocumentTypeCmd>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public CreateDocumentTypeCmdValidator(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .MustAsync(CodeMustBeUnique).WithMessage("Code must be unique"); ;

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.Purpose)
                .Must(BeAValidPurpose).WithMessage("At least one valid document purpose is required");

        }

        private Task<bool> CodeMustBeUnique(string code, CancellationToken token)
        {
            return _documentTypeRepository.IsUnique(code, token);
        }
        private bool BeAValidPurpose(DocumentPurpose purpose)
        {
            return purpose != 0 && Enum.IsDefined(typeof(DocumentPurpose), purpose);
        }
    }
}
