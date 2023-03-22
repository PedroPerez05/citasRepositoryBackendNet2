using AutoMapper;
using citasMedicasBackend2.Dto;
using citasMedicasBackend2.Models;

namespace citasMedicasBackend2.Configurations
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CitaDTOCrear, Cita>();
            CreateMap<Cita, CitaDTOCrear>();
            CreateMap<CitaDTO, Cita>();
            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaDTOSimp, Cita>();
            CreateMap<Cita, CitaDTOSimp>();
            CreateMap<CitaCrearDiagnostico, Cita>();
            CreateMap<Cita, CitaCrearDiagnostico>();
            CreateMap<MedicoDTOSimp, Medico>();
            CreateMap<Medico, MedicoDTOSimp>();
            CreateMap<PacienteDTOSimp, Paciente>();
            CreateMap<Paciente, PacienteDTOSimp>();
            CreateMap<DiagnosticoDTO, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTOCrear, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoDTOCrear>();
            CreateMap<PacienteDTOCrear, Paciente>();
            CreateMap<Paciente, PacienteDTOCrear>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTOCita, Paciente>();
            CreateMap<Paciente, PacienteDTOCita>();
            CreateMap<MedicoDTOCita, Medico>();
            CreateMap<Medico, MedicoDTOCita>();
            CreateMap<DiagnosticoDTOCita, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoDTOCita>();

        }
    }
}
