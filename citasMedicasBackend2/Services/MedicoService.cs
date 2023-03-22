using AutoMapper;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;

namespace citasMedicasBackend2.Services
{
    public class MedicoService
    {
        private readonly MedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoService(MedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<Medico> AñadirMedico(Medico medico)
        {
            await _medicoRepository.AddAsync(medico);
            return medico;
        }

        public async Task<IEnumerable<Medico>> ObtenerMedicos()
        {
            var medicos = await _medicoRepository.GetAllAsync();
            return medicos;
        }

        public async Task<Boolean> EliminarMedico(int id)
        {
            Medico medico = await _medicoRepository.GetByIdAsync(id);
            if (medico != null)
            {
                await _medicoRepository.DeleteAsync(medico);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Medico> VerMedico(int id)
        {
            Medico medico = await _medicoRepository.GetByIdAsync(id);
            return medico;
        }

        public async Task<Medico> ModificarMedico(Medico medico)
        {
            await _medicoRepository.UpdateAsync(medico);
            return await _medicoRepository.GetByIdAsync(medico.Id);
        }
    }
}