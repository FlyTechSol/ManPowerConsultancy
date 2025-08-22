using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Training.Command.Update
{
    public class UpdateTrainingCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string TrainingName { get; set; } = string.Empty;
        public string? TrainingInstitute { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TrainingEndDate { get; set; }
        public string? TrainingRemarks { get; set; }
        public string? TrainingCertificateUrl { get; set; }
    }
}
