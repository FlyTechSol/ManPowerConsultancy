using MediatR;

namespace MC.Application.Features.Master.ZipCode.Command.Create
{
    public class CreateZipCodeCmd : IRequest<Guid>
    {
        public string Zipcode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
