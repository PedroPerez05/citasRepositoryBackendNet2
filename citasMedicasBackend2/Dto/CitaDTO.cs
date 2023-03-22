using citasMedicasBackend2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace citasMedicasBackend2.Dto
{
    public class CitaDTO
    {
        public int Id { set; get; }
        public DateTime FechaHora { set; get; }

        public String MotivoCita { set; get; }
        public virtual DiagnosticoDTO Diagnostico { set; get; }
        public virtual PacienteDTOCita Paciente { set; get; }
        public virtual MedicoDTOCita Medico { set; get; }
    }
}
