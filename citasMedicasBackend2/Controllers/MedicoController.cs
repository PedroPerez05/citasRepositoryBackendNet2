using Microsoft.AspNetCore.Mvc;

namespace citasMedicasBackend2.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //[controller] hace referencia a "Medico"
    public class MedicoController : Controller
    {
        //hacer constructores
        [HttpGet]
        public String obtenerMedicos()
        {
            return "Hola";
        }
    }
}
