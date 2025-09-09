using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Create
{
    public class CreateAddressCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public AddressType AddressType { get; set; }
        //public string P_AddressLine1 { get; set; } = string.Empty;
        //public string P_AddressLine2 { get; set; } = string.Empty;
        //public string P_PinCode { get; set; } = string.Empty;
        //public string P_City { get; set; } = string.Empty;
        //public string P_District { get; set; } = string.Empty;
        //public string P_State { get; set; } = string.Empty;
        //public string P_Country { get; set; } = string.Empty;
    }
}
