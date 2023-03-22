using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Models
{
    [Table("Paciente")]
    public class Paciente : Usuario //este signo ":" es igual que decir extends en java
    {
        //[Column]
        public String Nss { set; get; }
        //[Column]
        public String NumTarjeta { set; get; }
       // [Column]
        public String Telefono { set; get; }
       // [Column]
        public String Direccion { set; get; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
