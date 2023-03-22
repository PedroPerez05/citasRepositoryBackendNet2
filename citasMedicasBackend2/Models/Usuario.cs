using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Models
{
   [Table("Usuario")]
    public class Usuario
    {
        //[Required (ErrorMessage ="EL nombre es obligatorio")]//->Indica que el atributo es obligatorio para la api
       // [Key]
        public int Id { get; set; }
       // [Column]
        public String Nombre { set; get; }
       // [Column]
        public String Apellidos { set; get; }
       // [Column]
        public String NomUsuario { set; get; }
       // [Column]
        public String Clave { set; get; }

    }
}
