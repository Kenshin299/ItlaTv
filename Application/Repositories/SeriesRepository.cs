using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class SeriesRepository
    {
        private readonly ItlaTvDbContext _dbContext;

        public SeriesRepository(ItlaTvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Series series)
        {
            await _dbContext.Set<Series>().AddAsync(series);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Series series)
        {
            _dbContext.Entry(series).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Series entity)
        {
            _dbContext.Set<Series>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Series>> GetAllAsync()
        {
            return await _dbContext
                .Set<Series>()
                .Include(s => s.Genres)   
                .Include(s => s.Producer) 
                .ToListAsync();
        }

        public async Task<Series> GetByIdAsync(int id)
        {
            return await _dbContext
                 .Set<Series>()
                 .FindAsync(id);
        }
    }
}
