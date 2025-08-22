using MediatR;

namespace MC.Application.Features.Master.Country.Command.Create
{
    public class CreateCountryCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string? DialCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
