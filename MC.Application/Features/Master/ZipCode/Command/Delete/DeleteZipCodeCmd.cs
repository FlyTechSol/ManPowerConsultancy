using MediatR;

namespace MC.Application.Features.Master.ZipCode.Command.Delete
{
    public class DeleteZipCodeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
