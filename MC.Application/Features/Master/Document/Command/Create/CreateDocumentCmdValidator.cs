using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Document.Command.Create
{
   public class CreateDocumentCmdValidator : AbstractValidator<CreateDocumentCmd>
    {
        private readonly IDocumentRepository _documentRepository;

        public CreateDocumentCmdValidator(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

            RuleFor(p => p.DocumentName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(q => q)
                .MustAsync(CodeMustUnique)
                .WithMessage("Document record already exists");
        }

        private Task<bool> CodeMustUnique(CreateDocumentCmd command, CancellationToken token)
        {
            return _documentRepository.IsUnique(command.DocumentName, token);
        }
    }
}
