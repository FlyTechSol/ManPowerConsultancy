using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Command.Create
{
    public class CreateInsuranceCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string InsuranceCompanyName { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public string? PolicyRemarks { get; set; }
    }
}
