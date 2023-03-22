namespace citasMedicasBackend2.Dto
{
    public class CitaCrearDiagnostico
    {
        public DateTime FechaHora { set; get; }

        public String MotivoCita { set; get; }

        public DiagnosticoDTO diagnostico { set; get; }
    }
}
