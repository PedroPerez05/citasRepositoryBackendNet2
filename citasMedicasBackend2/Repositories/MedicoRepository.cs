using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Models;
using Microsoft.EntityFrameworkCore;

namespace citasMedicasBackend2.Repositories
{
    public class MedicoRepository : IRepository<Medico>
    {
        private readonly ApplicationDbContext _dbContext;

        public MedicoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Medico entity)
        {
            await _dbContext.Medicos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medico entity)
        {
            _dbContext.Medicos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _dbContext.Medicos
                .Include(m => m.Citas)
                .ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int id)
        {
            return await _dbContext.Medicos
                .Include(m => m.Citas)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Medico entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
