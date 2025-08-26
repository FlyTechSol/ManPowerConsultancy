using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
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

        public async Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var address = await _context.BankAccounts
                .AsNoTracking()
                .Include(ba => ba.UserProfile)
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive && !addr.IsDeleted)
                .Select(addr => new BankAccountDetailDto
                {
                    Id = addr.Id,
                    UserProfileId = addr.UserProfileId,
                    UserProfileName = addr.UserProfile != null ? addr.UserProfile.FirstName + " " + addr.UserProfile.LastName : string.Empty,
                    BankName = addr.BankName,
                    IFSCCode = addr.IFSCCode,
                    AccountNo = addr.AccountNo,
                    AccountType = addr.AccountType,
                    IsPassBookAvailable = addr.IsPassbookAvailable,
                    PassbookUrl = addr.PassbookUrl,
                    IsActive = addr.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(addr.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(addr.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(addr.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(addr.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return address;
        }

        public async Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            // Step 2: Get all INACTIVE record for that user
            var addresses = await _context.BankAccounts
                .AsNoTracking()
                .Include(ba => ba.UserProfile)
                .Where(bank => bank.UserProfileId == userProfile.Id && !bank.IsActive && !bank.IsDeleted)
                .Select(bank => new BankAccountDetailDto
                {
                    Id = bank.Id,
                    UserProfileId = bank.UserProfileId,
                    UserProfileName = bank.UserProfile != null ? bank.UserProfile.FirstName + " " + bank.UserProfile.LastName : string.Empty,
                    BankName = bank.BankName,
                    IFSCCode = bank.IFSCCode,
                    AccountNo = bank.AccountNo,
                    AccountType = bank.AccountType,
                    IsPassBookAvailable = bank.IsPassbookAvailable,
                    PassbookUrl = bank.PassbookUrl,
                    IsActive = bank.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(bank.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(bank.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(bank.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(bank.ModifiedByUser),
                })
                .ToListAsync(cancellationToken);
            return addresses;
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
                .Include(a => a.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new BankAccountDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                BankName = response.BankName,
                IFSCCode = response.IFSCCode,
                AccountNo = response.AccountNo,
                AccountType = response.AccountType,
                IsPassBookAvailable = response.IsPassbookAvailable,
                PassbookUrl = response.PassbookUrl,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
            return dto;
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
    }
}
