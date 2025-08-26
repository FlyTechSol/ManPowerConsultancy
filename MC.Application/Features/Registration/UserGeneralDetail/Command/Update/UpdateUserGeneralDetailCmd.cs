using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Command.Update
{
    public class UpdateUserGeneralDetailCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? SpouseName { get; set; }
        public Guid? ReligionId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CasteCategoryId { get; set; }
        public bool DifferentlyAbled { get; set; } = false;
        public Guid? HighestEducationId { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }  // ✅ Spelling corrected from "MaritialStatus"
        public string? IdentityMarks { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
