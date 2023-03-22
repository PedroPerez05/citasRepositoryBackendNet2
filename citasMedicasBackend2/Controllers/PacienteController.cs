using AutoMapper;
using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;
using citasMedicasBackend2.Services;
using Microsoft.AspNetCore.Mvc;

namespace citasMedicasBackend2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PacienteService _pacienteService;

        public PacienteController(IMapper mapper, PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> añadirPaciente([FromBody] PacienteDTOCrear PacienteDTO)
        {
            var paciente = _mapper.Map<PacienteDTOCrear, Paciente>(PacienteDTO);
            await _pacienteService.añadirPaciente(paciente);
            return _mapper.Map<Paciente, PacienteDTO > (paciente);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> obtenerCitas()
        {
            var pacientes = await _pacienteService.obtenerPacientes();
            var pacientesDTO = _mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteDTO>>(pacientes);
            return Ok(pacientesDTO);
        }

        [HttpDelete("id")]
        public async Task<String> eliminarPaciente(int id)
        {
            if (await _pacienteService.eliminarPaciente(id) == true)
            {
                return "Paciente eliminado correctamente "+ id;
            }
            else
            {
                return "Paciente no encontrado"+ id;
            }
        }
        [HttpGet("id")]
        public async Task<PacienteDTO> verPaciente(int id)
        {
            Paciente c = await _pacienteService.verPaciente(id);
            if (c == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<Paciente, PacienteDTO>(c);
            }
        }
        [HttpPut("id")]
        public async Task<PacienteDTO> modificarPaciente(int id, [FromBody] PacienteDTOCrear citaDTO)
        {
            var cita = _mapper.Map<PacienteDTOCrear, Paciente>(citaDTO);
            cita.Id = id;
            Paciente c = await _pacienteService.modificarPaciente(cita);
            return _mapper.Map<Paciente, PacienteDTO>(c);
        }
    }
}
