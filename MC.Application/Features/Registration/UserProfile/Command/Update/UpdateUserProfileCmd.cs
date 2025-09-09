using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.UserProfile.Command.Update
{
    public class UpdateUserProfileCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        //public Guid? UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ClientMasterId { get; set; }
        public Guid ClientUnitId { get; set; }
        public Guid BranchId { get; set; }
        public Guid DesignationId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? TitleId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public Guid? RecruitmentTypeId { get; set; }
        public string AadhaarNumber { get; set; } = string.Empty;
        public string? PanNo { get; set; }
        public string? UanNumber { get; set; }
        public string? EsicNumber { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public Guid? GenderId { get; set; }
        public string? IdentityMarks { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
