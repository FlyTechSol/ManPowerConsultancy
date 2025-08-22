using MediatR;

namespace MC.Application.Features.Master.Country.Command.Delete
{
    public class DeleteCountryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
