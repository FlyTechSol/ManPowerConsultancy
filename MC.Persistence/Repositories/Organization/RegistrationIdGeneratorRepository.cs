using MC.Application.Contracts.Persistence.Organization;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Organization
{
    public class RegistrationIdGeneratorRepository : GenericRepository<Domain.Entity.Organization.RegistrationSequence>, IRegistrationIdGeneratorRepository
    {
        public RegistrationIdGeneratorRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<string> GetNextRegistrationIdAsync(Guid companyId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var sequence = await _context.RegistrationSequences
                .FirstOrDefaultAsync(s => s.CompanyId == companyId);

            if (sequence == null)
                throw new InvalidOperationException("Registration sequence not initialized for this company.");

            sequence.LastRegistrationId += 1;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            var formattedId = $"{sequence.Prefix}-{sequence.LastRegistrationId:D4}";
            return formattedId;
        }
    }
}
