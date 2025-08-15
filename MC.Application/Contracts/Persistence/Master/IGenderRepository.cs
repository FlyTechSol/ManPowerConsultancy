using MC.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IGenderRepository : IGenericRepository<Gender>
    {
        Task<Gender?> GetByCodeAsync(string code);
    }
}
