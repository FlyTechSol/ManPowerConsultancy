using FluentValidation;
using MC.Application.Contracts.Persistence.Master;

namespace MC.Application.Features.Master.Document.Command.Update
{
    public class UpdateDocumentCmdValidator : AbstractValidator<UpdateDocumentCmd>
    {
        private readonly IDocumentRepository _documentRepository;

        public UpdateDocumentCmdValidator(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.DocumentName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .MustAsync((command, documentName, cancellationToken) =>
                    DecodeMustBeUniqueForUpdate(command.Id, documentName, cancellationToken))
                .WithMessage("{PropertyName} must be unique.");


            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        }

        private async Task<bool> DecodeMustBeUniqueForUpdate(Guid id, string documentName, CancellationToken cancellationToken)
        {
            var isUnique = await _documentRepository.IsUniqueForUpdate(id, documentName, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _documentRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
