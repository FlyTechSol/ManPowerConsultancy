using MediatR;

namespace MC.Application.Features.Organization.Company.Command.Delete
{
    public class DeleteCompanyCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
