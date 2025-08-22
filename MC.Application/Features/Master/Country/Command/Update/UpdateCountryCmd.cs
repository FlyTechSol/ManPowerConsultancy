using MediatR;

namespace MC.Application.Features.Master.Country.Command.Update
{
    public class UpdateCountryCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int? DisplayOrder { get; set; }
        public string? DialCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
