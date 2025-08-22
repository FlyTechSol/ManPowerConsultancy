using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class InsuranceNomineeDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
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
        public bool IsActive { get; set; }
    }
}
