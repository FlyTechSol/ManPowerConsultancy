using MC.Application.Contracts.Persistence.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class RegistrationIdGeneratorRepository : IRegistrationIdGeneratorRepository
    {
        private readonly ApplicationDatabaseContext _dbContext;

        public RegistrationIdGeneratorRepository(ApplicationDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetNextRegistrationIdAsync()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            var sequence = await _dbContext.RegistrationSequences
                .FirstOrDefaultAsync(s => s.Id == 1);

            if (sequence == null)
                throw new InvalidOperationException("Registration sequence not initialized.");

            sequence.LastRegistrationId += 1;

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return sequence.LastRegistrationId;
        }
    }
}
