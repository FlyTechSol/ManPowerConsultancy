using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class ZipCodeRepository : GenericRepository<ZipCode>, IZipCodeRepository
    {
        public ZipCodeRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<ZipCodeDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.ZipCodes
                .AsNoTracking()
                .Where(q => q.IsDeleted == false)
                .Select(lt => new ZipCodeDto
                {
                    Id = lt.Id,
                    Zipcode = lt.Zipcode,
                    City = lt.City,
                    State = lt.State,
                    District = lt.District,
                    Country = lt.Country,
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<ZipCodeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ZipCodes
                .AsNoTracking()
                .Include(lt => lt.CreatedByUser)
                .Include(lt => lt.ModifiedByUser)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;
            return MapToDto(response);
        }
        public async Task<ZipCodeDetailDto?> GetDetailsByZipCodeAsync(string zipCode, CancellationToken cancellationToken)
        {
            var response = await _context.ZipCodes
                .AsNoTracking()
                .Include(lt => lt.CreatedByUser)
                .Include(lt => lt.ModifiedByUser)
                .FirstOrDefaultAsync(lt => lt.Zipcode == zipCode && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;
            return MapToDto(response);
        }
        public async Task<bool> IsUnique(string zipCode, CancellationToken cancellationToken)
        {
            return !await _context.ZipCodes
               .AsNoTracking()
               .AnyAsync(q => q.Zipcode == zipCode && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.ZipCodes
                .AsNoTracking()
                .AnyAsync(q => q.Zipcode == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private ZipCodeDetailDto MapToDto(ZipCode response)
        {
            return new ZipCodeDetailDto
            {
                Id = response.Id,
                Zipcode = response.Zipcode,
                City = response.City,
                State = response.State,
                District = response.District,
                Country = response.Country,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
        }
    }
}
