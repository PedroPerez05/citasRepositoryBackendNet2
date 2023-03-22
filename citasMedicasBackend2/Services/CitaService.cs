using AutoMapper;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;

namespace citasMedicasBackend2.Services
{
    public class CitaService
    {
        private readonly CitaRepository _citaRepository;
        private readonly DiagnosticoRepository _diagnosticoRepository;
        private readonly IMapper _mapper;
        public CitaService(CitaRepository citaRepository, IMapper mapper, DiagnosticoRepository diagnosticoRepository)
        {
            _mapper = mapper;
            _citaRepository = citaRepository;
            _diagnosticoRepository= diagnosticoRepository;
        }
        public async Task<Cita> añadirCita(Cita cita)
        {
           await _citaRepository.AddAsync(cita);
            return cita;
        }
        public async Task<IEnumerable<Cita>> obtenerCitas()
        {
            var citas = await _citaRepository.GetAllAsync();
            return citas;
        }
        public async Task<Boolean> eliminarCita(int id)
        {
            int idDiagnostico = 0;
            Cita c = await _citaRepository.GetByIdAsync(id);
            if (c != null)
            {
                idDiagnostico = c.DiagnosticoId;
                await _diagnosticoRepository.DeleteAsync(await _diagnosticoRepository.GetByIdAsync(idDiagnostico));
                await _citaRepository.DeleteAsync(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Cita> verCita(int id)
        {
            Cita c = await _citaRepository.GetByIdAsync(id);
            if (c != null)
            {
                await _citaRepository.DeleteAsync(c);
                return c;
            }
            else
            {
                return null;
            }
        }
        public async Task<Cita> modificarCita(Cita cita)
        {
            await _citaRepository.UpdateAsync(cita);
            return await _citaRepository.GetByIdAsync(cita.Id);
        }
    }
}
