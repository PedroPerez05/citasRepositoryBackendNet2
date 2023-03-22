using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Models;
using Microsoft.EntityFrameworkCore;

namespace citasMedicasBackend2.Repositories
{
    public class CitaRepository : IRepository<Cita>
    {
        private readonly ApplicationDbContext _dbContext;

        public CitaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task AddAsync(Cita entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _dbContext.Citas
                         .Include(c => c.Paciente)
                         .Include(c => c.Medico)
                         .Include(c => c.Diagnostico)
                         .ToListAsync(); ;
        }

        public async Task DeleteAsync(Cita entity)
        {
             _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }



        public async Task<Cita> GetByIdAsync(int id)
        {
            return await _dbContext.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Diagnostico)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Cita entity)
        {
            Cita citaActualizar = await GetByIdAsync(entity.Id);
            if (citaActualizar != null)
            {
                citaActualizar.MotivoCita = entity.MotivoCita;
                citaActualizar.Paciente = entity.Paciente;
                citaActualizar.Medico = entity.Medico;
                citaActualizar.Diagnostico = entity.Diagnostico;
                _dbContext.Update(citaActualizar);
               await _dbContext.SaveChangesAsync();
            }
        }
    }
}
