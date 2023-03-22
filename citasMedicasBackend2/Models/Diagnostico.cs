using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Models
{
    //[Table("Diagnostico")]
    public class Diagnostico
    {
        //[Key]
        public int Id { set; get; }
        //[Column]
        public String ValoracionEspecialista { set; get; }
        //[Column]
        public String Enfermedad { set; get; }

        //public int CitaId { set; get; }
        public Cita Cita { set; get; }

    }
}
