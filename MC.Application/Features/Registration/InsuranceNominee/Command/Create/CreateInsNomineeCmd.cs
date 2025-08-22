using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Create
{
    public class CreateInsNomineeCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string NominatedBy { get; set; } = string.Empty;
        public string NominatedByFather { get; set; } = string.Empty;
        public string? SoldierNumber { get; set; }
        public string? SoldierRank { get; set; }
        public string? SoldierUnit { get; set; }
        public DateTime NominatedByDoB { get; set; }
        public string? NominatedByPermanentAddress { get; set; }
        public string? NominatedByCorrespondenceAddress { get; set; }
        public string? NomineeName { get; set; }
        public string? RelationWithNominee { get; set; }
        public string? NomineeFather { get; set; }
        public DateTime NomineeDoB { get; set; }
        public string? NomineeByPermanentAddress { get; set; }
        public string? NomineeByCorrespondenceAddress { get; set; }
    }
}
