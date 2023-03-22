using AutoMapper;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;

namespace citasMedicasBackend2.Services
{
    public class DiagnosticoService
    {
        private readonly DiagnosticoRepository _diagnosticoRepository;
        private readonly IMapper _mapper;
        public DiagnosticoService(DiagnosticoRepository diagnosticoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _diagnosticoRepository = diagnosticoRepository;
        }
        public async Task<Diagnostico> crearDiagnostico(Diagnostico diagnostico)
        {
            await _diagnosticoRepository.AddAsync(diagnostico);
            return diagnostico;
        }
        public async Task<IEnumerable<Diagnostico>> obtenerDiagnosticos()
        {
            var diagnosticos = await _diagnosticoRepository.GetAllAsync();
            return diagnosticos;
        }
        public async Task<Boolean> eliminarDiagnostico(int id)
        {
            Diagnostico c = await _diagnosticoRepository.GetByIdAsync(id);
            if (c != null)
            {
                await _diagnosticoRepository.DeleteAsync(c);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Diagnostico> verDiagnostico(int id)
        {
            Diagnostico c = await _diagnosticoRepository.GetByIdAsync(id);
            if (c != null)
            {
                await _diagnosticoRepository.DeleteAsync(c);
                return c;
            }
            else
            {
                return null;
            }
        }
    }
}
