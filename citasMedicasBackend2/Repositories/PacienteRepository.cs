using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Models;
using Microsoft.EntityFrameworkCore;

namespace citasMedicasBackend2.Repositories
{
    public class PacienteRepository : IRepository<Paciente>
    {
        private readonly ApplicationDbContext _dbContext;

        public PacienteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Paciente entity)
        {
         
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }

        public async Task DeleteAsync(Paciente entity)
        {
         
                     _dbContext.Remove(entity);
                     await _dbContext.SaveChangesAsync();
                }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _dbContext.Pacientes
                    .Include(c => c.Citas)
                    .Include(c => c.Medicos)
                    .ToListAsync(); ;
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _dbContext.Pacientes
                   .Include(c => c.Citas)
                   .Include(c => c.Medicos)
                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Paciente entity)
        {
            throw new NotImplementedException();
        }
    }
}
