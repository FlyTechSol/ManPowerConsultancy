using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Command.Create
{
   public class CreateResignationCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public DateTime ResignationDate { get; set; }
        public string Reason { get; set; } = string.Empty; 
    }
}
