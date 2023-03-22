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
    public class CitaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CitaService _citaService;

        //private readonly ApplicationDbContext _dbContext;
        public CitaController(IMapper mapper, /*ApplicationDbContext dbContext*/ CitaService citaService)
        {
            //_dbContext = dbContext;
            _citaService = citaService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<CitaDTO>> añadirCita([FromBody] CitaDTOCrear citaDTO)
        {
            var cita = _mapper.Map<CitaDTOCrear, Cita>(citaDTO);
            await _citaService.añadirCita(cita);
            return _mapper.Map<Cita, CitaDTO>(cita); ;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> obtenerCitas()
        {
            var citas = await _citaService.obtenerCitas();
            var citasDTO = _mapper.Map<IEnumerable<Cita>, IEnumerable<CitaDTO>>(citas);
            return Ok(citasDTO);
        }

        [HttpDelete("id")]
        public async Task<String> eliminarCita(int id)
        {
            if (await _citaService.eliminarCita(id) == true)
            {
                return "Cita eliminada correctamente";
            }
            else
            {
                return "Cita no encontrada";
            }
        }
        [HttpGet("id")]
        public async Task<CitaDTO> verCita(int id)
        {
            Cita c = await _citaService.verCita(id);
            if (c == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<Cita, CitaDTO>(c);
            }
        }
        [HttpPut("id")]
        public async Task<CitaDTO> modificarCita(int id, [FromBody] CitaDTOCrear citaDTO)
        {
            var cita = _mapper.Map<CitaDTOCrear, Cita>(citaDTO);
            cita.Id = id;
            Cita c=await _citaService.modificarCita(cita);
            return _mapper.Map<Cita, CitaDTO>(c);
        }
    }
}
