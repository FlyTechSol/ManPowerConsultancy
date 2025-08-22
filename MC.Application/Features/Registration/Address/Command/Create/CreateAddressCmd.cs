using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Create
{
    public class CreateAddressCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string C_AddressLine1 { get; set; } = string.Empty;
        public string C_AddressLine2 { get; set; } = string.Empty;
        public string C_PinCode { get; set; } = string.Empty;
        public string C_City { get; set; } = string.Empty;
        public string C_District { get; set; } = string.Empty;
        public string C_State { get; set; } = string.Empty;
        public string C_Country { get; set; } = string.Empty;
        public bool IsPermanentAddressSame { get; set; }
        public string P_AddressLine1 { get; set; } = string.Empty;
        public string P_AddressLine2 { get; set; } = string.Empty;
        public string P_PinCode { get; set; } = string.Empty;
        public string P_City { get; set; } = string.Empty;
        public string P_District { get; set; } = string.Empty;
        public string P_State { get; set; } = string.Empty;
        public string P_Country { get; set; } = string.Empty;
    }
}
