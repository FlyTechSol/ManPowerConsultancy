using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Update
{
    public class UpdateResignationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public DateTime ResignationDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
