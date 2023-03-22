using AutoMapper;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;

namespace citasMedicasBackend2.Services
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public PacienteService(PacienteRepository pacienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
        }
        public async Task<Paciente> añadirPaciente(Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
            return paciente;
        }
        public async Task<IEnumerable<Paciente>> obtenerPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return pacientes;
        }
        public async Task<Boolean> eliminarPaciente(int id)
        {
            Paciente c = await _pacienteRepository.GetByIdAsync(id);
            if (c != null)
            {
                await _pacienteRepository.DeleteAsync(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Paciente> verPaciente(int id)
        {
            Paciente c = await _pacienteRepository.GetByIdAsync(id);
            if (c != null)
            {
                await _pacienteRepository.DeleteAsync(c);
                return c;
            }
            else
            {
                return null;
            }
        }
        public async Task<Paciente> modificarPaciente(Paciente paciente)
        {
            await _pacienteRepository.UpdateAsync(paciente);
            return await _pacienteRepository.GetByIdAsync(paciente.Id);
        }
    }
}
