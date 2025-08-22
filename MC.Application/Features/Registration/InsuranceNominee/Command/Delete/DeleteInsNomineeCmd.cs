using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Command.Delete
{
    public class DeleteInsNomineeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
