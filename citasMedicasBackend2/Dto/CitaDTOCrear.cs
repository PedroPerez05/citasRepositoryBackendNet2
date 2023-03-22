using citasMedicasBackend2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Dto
{
    public class CitaDTOCrear
    {
        //public int Id { set; get; }
        public DateTime FechaHora { set; get; }
  
        public String MotivoCita { set; get; }
        public virtual DiagnosticoDTOCita Diagnostico { set; get; }
        public virtual PacienteDTOSimp Paciente { set; get; }
        public virtual MedicoDTOSimp Medico { set; get; }
    }
}
