using FluentValidation;
using MC.Application.Contracts.Persistence.Organization;

namespace MC.Application.Features.Organization.ClientUnit.Command.Update
{
    public class UpdateUnitCmdValidator : AbstractValidator<UpdateUnitCmd>
    {
        private readonly IUnitRepository _unitRepository;

        public UpdateUnitCmdValidator(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(RecordMustExist);

            RuleFor(p => p.ClientMasterId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.UnitName)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
             .MustAsync((cmd, unitName, token) => BeUniqueUnitName(cmd.Id, cmd.ClientMasterId, unitName, token))
             .WithMessage("Unit name must be unique within the same client.");
        }

        private Task<bool> BeUniqueUnitName(Guid id, Guid clientMasterId, string unitName, CancellationToken cancellationToken)
        {
            return _unitRepository.IsUniqueForUpdate(id, clientMasterId, unitName, cancellationToken);
        }

        private async Task<bool> RecordMustExist(Guid id, CancellationToken cancellationToken)
        {
            var record = await _unitRepository.GetByIdAsync(id, cancellationToken);
            return record != null;
        }
    }
}
