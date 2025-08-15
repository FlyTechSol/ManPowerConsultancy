using MC.Application.Contracts.Persistence;
using MC.Application.Exceptions;
using MC.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MC.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDatabaseContext _context;

        public GenericRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e => !e.IsDeleted)
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(typeof(T).Name, id);

            return entity;
        }
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e => !e.IsDeleted)
                .FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var query = _context.Set<T>().Where(e => !e.IsDeleted);
            if (predicate != null)
                query = query.Where(predicate);

            return await query.CountAsync();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Expression<Func<T, bool>> predicate, Action<T> updateAction)
        {
            var entities = await _context.Set<T>().Where(predicate).ToListAsync();
            foreach (var entity in entities)
            {
                updateAction(entity);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                throw new NotFoundException(typeof(T).Name, id);

            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .Where(e => !e.IsDeleted)
                .AnyAsync(predicate);
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await AnyAsync(predicate); // reusing AnyAsync
        }
    }
}
