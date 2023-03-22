using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Dto
{
    public class UsuarioDTO
    {
       // public int Id { get; set; }
        public String Nombre { set; get; }
        public String Apellidos { set; get; }
        public String NomUsuario { set; get; }
        public String Clave { set; get; }
    }
}
