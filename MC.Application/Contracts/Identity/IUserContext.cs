using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Identity
{
    public interface IUserContext
    {
        string UserId { get; }          // string form (from claim/header)
        Guid UserGuidId { get; }        // parsed Guid
        string UserName { get; }        // display name
        string Email { get; }           // email from claims
        string[] Roles { get; }         // all role names from claims
        bool IsAuthenticated { get; }   // quick check if user is logged in
    }
}
