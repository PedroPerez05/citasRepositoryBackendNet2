using citasMedicasBackend2.Models;

namespace citasMedicasBackend2.Dto
{
    public class MedicoDTOCita : UsuarioDTO
    {
        public int Id { get; set; }
        public String NumColegiado { set; get; }
    }
}