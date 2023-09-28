using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProducerRepository
    {
        private readonly ItlaTvDbContext _dbContext;

        public ProducerRepository(ItlaTvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Producer producer)
        {
            await _dbContext.Set<Producer>().AddAsync(producer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producer producer)
        {
            _dbContext.Entry(producer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Producer entity)
        {
            _dbContext.Set<Producer>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Producer>> GetAllAsync()
        {
            return await _dbContext
                 .Set<Producer>()
                 .ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _dbContext
                 .Set<Producer>()
                 .FindAsync(id);
        }
    }
}
