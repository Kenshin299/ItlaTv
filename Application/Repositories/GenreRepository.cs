using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class GenreRepository
    {
        private readonly ItlaTvDbContext _dbContext;

        public GenreRepository(ItlaTvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Genre genre)
        {
            await _dbContext.Set<Genre>().AddAsync(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _dbContext.Entry(genre).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _dbContext.Set<Genre>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext
                 .Set<Genre>()
                 .ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _dbContext
                 .Set<Genre>()
                 .FindAsync(id);
        }
    }
}
