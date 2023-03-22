using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Models;
using Microsoft.EntityFrameworkCore;

namespace citasMedicasBackend2.Repositories
{
    public class DiagnosticoRepository : IRepository<Diagnostico>
    {
        private readonly ApplicationDbContext _dbContext;

        public DiagnosticoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Diagnostico entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Diagnostico entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Diagnostico>> GetAllAsync()
        {
            return await _dbContext.Diagnosticos
             .Include(c => c.Cita)
             .ToListAsync(); ;
        }

        public async Task<Diagnostico> GetByIdAsync(int id)
        {
            return await _dbContext.Diagnosticos
                 .Include(c => c.Cita)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Diagnostico entity)
        {
            throw new NotImplementedException();
        }
    }
}
