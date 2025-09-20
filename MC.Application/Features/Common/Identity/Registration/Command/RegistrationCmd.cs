using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Registration;
using MediatR;

namespace MC.Application.Features.Common.Identity.Registration.Command
{
    public class RegistrationCmd : IRequest<RegistrationResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
        public Guid? CompanyId { get; set; }
    }
}
