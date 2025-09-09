using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Enum.Approval
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled,    // withdrawn by requester
        InProgress    // partially approved (some stages done, others pending)
    }
}
