using Hotel.Core.DataContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel.Core.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly HotelDbContext _context;
        private readonly DbSet<T> _set;


        public GenericRepository(HotelDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var value = await GetByIdAsync(id);
            if (value is not null)
            {
                _set.Remove(value);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _set.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Predicate(Func<T, bool> predicate) {
        
            return _set.Any(predicate);
        }

        public List<T> Filter(Func<T, bool> predicate)
        {
            return _set.Where(predicate).ToList();  
        }
    }
}
