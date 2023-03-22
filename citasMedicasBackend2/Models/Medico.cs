using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Models
{
    [Table("Medico")]
    public class Medico : Usuario
    {
        //[Column]
        public String NumColegiado { set; get; }

        public ICollection<Cita> Citas { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
