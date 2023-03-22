using AutoMapper;
using citasMedicasBackend2.Datos;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;
using citasMedicasBackend2.Repositories;
using citasMedicasBackend2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace citasMedicasBackend2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DiagnosticoService _diagnosticoService;

        public DiagnosticoController(IMapper mapper, DiagnosticoService diagnosticoService)
        {
            _mapper = mapper;
            _diagnosticoService = diagnosticoService;
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosticoDTO>> crearDiagnostico([FromBody] DiagnosticoDTOCrear diagnosticoDTO)
        {
            var diagnostico = _mapper.Map<DiagnosticoDTOCrear, Diagnostico>(diagnosticoDTO);
            await _diagnosticoService.crearDiagnostico(diagnostico);
            return _mapper.Map<Diagnostico, DiagnosticoDTO > (diagnostico); ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosticoDTO>>> obtenerDiagnosticos()
        {
            var diagnosticos = await _diagnosticoService.obtenerDiagnosticos();
            var diagnosticosDTO = _mapper.Map<IEnumerable<Diagnostico>, IEnumerable<DiagnosticoDTO>>(diagnosticos);
            return Ok(diagnosticosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticoDTO>> verDiagnostico(int id)
        {
            Diagnostico diagnostico = await _diagnosticoService.verDiagnostico(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            else
            {
                return _mapper.Map<Diagnostico, DiagnosticoDTO>(diagnostico);
            }
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult<DiagnosticoDTO>> ModificarDiagnostico(int id, [FromBody] DiagnosticoDTOCrear diagnosticoDTO)
        {
            var diagnostico = _mapper.Map<DiagnosticoDTOCrear, Diagnostico>(diagnosticoDTO);
            diagnostico.Id = id;
            Diagnostico diag = await _diagnosticoService.modificarDiagnostico(diagnostico);
            return _mapper.Map<Diagnostico, DiagnosticoDTO>(diag);
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarDiagnostico(int id)
        {
            if (await _diagnosticoService.eliminarDiagnostico(id) == true)
            {
                return Ok("Diagnóstico eliminado correctamente");
            }
            else
            {
                return NotFound();
            }
        }
    }
}