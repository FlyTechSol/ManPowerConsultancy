using FluentValidation;
using MC.Application.Contracts.Persistence.Master;
using MC.Domain.Entity.Enum.Common;

namespace MC.Application.Features.Master.DocumentType.Command.Update
{
    public class UpdateDocumentTypeCmdValidator : AbstractValidator<UpdateDocumentTypeCmd>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public UpdateDocumentTypeCmdValidator(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.Purpose)
                .Must(BeAValidPurpose).WithMessage("At least one valid document purpose is required");

            RuleFor(p => p.Name)
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
            var isUnique = await _documentTypeRepository.IsUniqueForUpdate(id, documentName, cancellationToken);
            return isUnique;
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _documentTypeRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
        private bool BeAValidPurpose(DocumentPurpose purpose)
        {
            //return purpose != 0 && Enum.IsDefined(typeof(DocumentPurpose), purpose);
            return purpose != DocumentPurpose.None;
        }
    }
}
