using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Models
{
    //[Table("Cita")]
    public class Cita
    {
        //[Key]
        public int Id { set; get; }
        //[Column]
        public DateTime FechaHora { set; get; }
        //[Column]
        public String MotivoCita { set; get; }

        //[ForeignKey("Diagnostico")]
        public int DiagnosticoId { set; get; }
        public Diagnostico Diagnostico { set; get; }

        //[ForeignKey("Paciente")]
        public int PacienteId { set; get; }
        public Paciente Paciente { set; get; }///SALTA UN ERROR

        //[ForeignKey("Medico")]
        public int MedicoId { set; get; }
        public Medico Medico { set; get; }


 
    }
}
