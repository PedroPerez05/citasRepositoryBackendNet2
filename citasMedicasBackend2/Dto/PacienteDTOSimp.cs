using citasMedicasBackend2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Dto
{
    public class PacienteDTOSimp : UsuarioDTO
    {
        public String Nss { set; get; }
        public String NumTarjeta { set; get; }
        public String Telefono { set; get; }
        public String Direccion { set; get; }
    }
}