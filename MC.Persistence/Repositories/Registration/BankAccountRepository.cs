using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        public BankAccountRepository(IUserProfileRepository userProfileRepository, IFileUploadRepository fileUploadRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<PaginatedResponse<BankAccountDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.BankAccounts
                .AsNoTracking()
                .Include(x => x.Bank)
                .Where(addr => addr.UserProfileId == userProfileId && !addr.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Bank.Name.ToLower().Contains(search) ||
                    q.IFSCCode.ToLower().Contains(search) ||
                    q.AccountNo.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.AccountType.ToString()) && q.AccountType.ToString().ToLower().Contains(search)
                );
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                //query = query.OrderBy(a => a.IsActive); // default sort
                query = query.OrderByDescending(a => a.IsActive)
                             .ThenBy(a => a.Bank.Name); // optional secondary sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<BankAccountDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        //public async Task<BankAccountDetailDto?> GetActiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        //{
        //    var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

        //    if (userProfile == null)
        //        return null;

        //    var bankAccounts = await _context.BankAccounts
        //        .AsNoTracking()
        //        .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive && !addr.IsDeleted)
        //        .FirstOrDefaultAsync(cancellationToken);

        //    return bankAccounts == null ? null : MapToDto(bankAccounts);
        //}

        //public async Task<List<BankAccountDetailDto>?> GetInactiveRecordByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        //{
        //    var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

        //    if (userProfile == null)
        //        return null;

        //    // Step 2: Get all INACTIVE record for that user
        //    var bankAccounts = await _context.BankAccounts
        //        .AsNoTracking()
        //        .Where(bank => bank.UserProfileId == userProfile.Id && !bank.IsActive && !bank.IsDeleted)
        //        .ToListAsync(cancellationToken);

        //    if (bankAccounts == null || bankAccounts.Count == 0)
        //        return new List<BankAccountDetailDto>();

        //    var dtos = bankAccounts.Select(MapToDto).ToList();
        //    return dtos;
        //}

        //public async Task<BankAccountDetailDto?> GetActiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var bankAccount = await _context.BankAccounts
        //        .AsNoTracking()
        //        .Where(addr => addr.UserProfileId == userProfileId && addr.IsActive && !addr.IsDeleted)
        //        .FirstOrDefaultAsync(cancellationToken);

        //    return bankAccount == null ? null : MapToDto(bankAccount);

        //}
        //public async Task<List<BankAccountDetailDto>?> GetInactiveRecordByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var bankAccounts = await _context.BankAccounts
        //        .AsNoTracking()
        //        .Where(bank => bank.UserProfileId == userProfileId && !bank.IsActive && !bank.IsDeleted)
        //        .ToListAsync(cancellationToken);

        //    if (bankAccounts == null || bankAccounts.Count == 0)
        //        return new List<BankAccountDetailDto>();

        //    var dtos = bankAccounts.Select(MapToDto).ToList();
        //    return dtos;
        //}
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
                .Include(ba => ba.Bank)
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

        public async Task<Guid> CreateBankAccountAsync(BankAccount request, IFormFile? passbookUrl, CancellationToken cancellationToken)
        {
            // start a transaction on your existing context
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                request.IsActive = true;

                // first save to generate Id
                _context.BankAccounts.Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                if (passbookUrl != null)
                {
                    // upload file first (to disk)
                    var url = await _fileUploadRepository
                        .UploadFileAsync(passbookUrl, "Passbook", false, cancellationToken);

                    // update DB with file path
                    request.PassbookUrl = url;
                    _context.BankAccounts.Update(request);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                // commit DB transaction
                await transaction.CommitAsync(cancellationToken);

                return request.Id;
            }
            catch
            {
                // roll back DB changes
                await transaction.RollbackAsync(cancellationToken);
                // optional: delete file if uploaded to avoid orphan files
                throw;
            }
        }

        public async Task<Guid> UpdateBankAccountAsync(BankAccount request, IFormFile? passbookUrl, CancellationToken cancellationToken)
        {
            var existing = await _context.BankAccounts
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (existing == null)
                throw new NotFoundException($"Bank account with Id {request.Id} not found", request.Id);

            //existing.UserId = userProfile.UserId;
            existing.BankId = request.BankId;
            existing.IFSCCode = request.IFSCCode;
            existing.AccountNo = request.AccountNo;
            existing.AccountType = request.AccountType;
            existing.IsPassbookAvailable = request.IsPassbookAvailable;
            existing.PassbookUrl = request.PassbookUrl;
            existing.IsActive = request.IsActive;

            if (passbookUrl != null)
            {
                // (optional) delete old file to avoid orphan files
                if (!string.IsNullOrWhiteSpace(existing.PassbookUrl) &&
                    System.IO.File.Exists(existing.PassbookUrl))
                {
                    System.IO.File.Delete(existing.PassbookUrl);
                }

                var url = await _fileUploadRepository.UploadFileAsync(passbookUrl, "Passbook", false, cancellationToken);
                existing.PassbookUrl = url;
            }

            _context.BankAccounts.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }

        private BankAccountDetailDto MapToDto(Domain.Entity.Registration.BankAccount response)
        {
            return new BankAccountDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
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
