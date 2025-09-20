using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Command.Create
{
   public class CreatePreviousExpCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string? CompanyWorked { get; set; }
        public string? Place { get; set; }
        public string? Duration { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? ReasonForLeft { get; set; }
        public DateTime? LeftDate { get; set; }
        public string? Remarks { get; set; }
    }
}
