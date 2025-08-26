using MediatR;

namespace MC.Application.Features.Registration.Insurance.Command.Delete
{
    public class DeleteInsuranceCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
