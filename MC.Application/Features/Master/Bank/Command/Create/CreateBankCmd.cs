using MediatR;

namespace MC.Application.Features.Master.Bank.Command.Create
{
    public class CreateBankCmd : IRequest<Guid>
    {
        public int? DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
