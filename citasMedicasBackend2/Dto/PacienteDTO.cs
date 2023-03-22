namespace citasMedicasBackend2.Dto
{
    public class PacienteDTO : UsuarioDTO
    {
        public int Id { get; set; }
        public String Nss { set; get; }
        public String NumTarjeta { set; get; }
        public String Telefono { set; get; }
        public String Direccion { set; get; }
        //public virtual ICollection<CitaCrearDiagnostico> Citas { get; set; }
        public virtual ICollection<MedicoDTOCita> Medicos { get; set; }
    }
}
