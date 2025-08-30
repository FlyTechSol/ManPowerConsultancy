using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public BankAccountRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var bankAccounts = await _context.BankAccounts
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive && !addr.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return bankAccounts == null ? null : MapToDto(bankAccounts);
        }

        public async Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            // Step 2: Get all INACTIVE record for that user
            var bankAccounts = await _context.BankAccounts
                .AsNoTracking()
                .Where(bank => bank.UserProfileId == userProfile.Id && !bank.IsActive && !bank.IsDeleted)
                .ToListAsync(cancellationToken);

            if (bankAccounts == null || bankAccounts.Count == 0)
                return new List<BankAccountDetailDto>();

            var dtos = bankAccounts.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<BankAccountDetailDto?> GetActiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var bankAccount = await _context.BankAccounts
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfileId && addr.IsActive && !addr.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return bankAccount == null ? null : MapToDto(bankAccount);

        }
        public async Task<List<BankAccountDetailDto>?> GetInactiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var bankAccounts = await _context.BankAccounts
                .AsNoTracking()
                .Where(bank => bank.UserProfileId == userProfileId && !bank.IsActive && !bank.IsDeleted)
                .ToListAsync(cancellationToken);

            if (bankAccounts == null || bankAccounts.Count == 0)
                return new List<BankAccountDetailDto>();

            var dtos = bankAccounts.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<BankAccount>> GetAllByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            return await _context.BankAccounts
                .AsNoTracking()
                .Where(ba => ba.UserProfileId == userProfileId && !ba.IsDeleted)
                .ToListAsync(cancellationToken);
        }
        public async Task UpdateRangeAsync(IEnumerable<BankAccount> bankaccounts, CancellationToken cancellationToken)
        {
            _context.BankAccounts.UpdateRange(bankaccounts);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<BankAccountDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.BankAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<bool> IsUnique(string ifscCode, string accountNo, CancellationToken cancellationToken)
        {
            return !await _context.BankAccounts.AsNoTracking().AnyAsync(q => q.IFSCCode == ifscCode && !q.IsDeleted && q.AccountNo == accountNo, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string ifscCode, string accountNo, CancellationToken cancellationToken)
        {
            return !await _context.BankAccounts.AsNoTracking()
               .AnyAsync(q => q.AccountNo == accountNo && q.IFSCCode == ifscCode && !q.IsDeleted
                           && q.Id != id, cancellationToken);
        }

        private BankAccountDetailDto MapToDto(Domain.Entity.Registration.BankAccount response)
        {
            return new BankAccountDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                BankId = response.BankId,
                BankName = response.Bank.Name,
                IFSCCode = response.IFSCCode,
                AccountNo = response.AccountNo,
                AccountType = response.AccountType,
                IsPassBookAvailable = response.IsPassbookAvailable,
                PassbookUrl = response.PassbookUrl,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
