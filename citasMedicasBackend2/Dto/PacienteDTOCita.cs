namespace citasMedicasBackend2.Dto
{
    public class PacienteDTOCita : UsuarioDTO
    {
        public int Id { get; set; }
        public String Nss { set; get; }
        public String NumTarjeta { set; get; }
        public String Telefono { set; get; }
        public String Direccion { set; get; }
    }
}
