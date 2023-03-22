using citasMedicasBackend2.Models;
using Microsoft.EntityFrameworkCore;

namespace citasMedicasBackend2.Datos

{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>()
                .HasMany(p => p.Pacientes)
                .WithMany(m => m.Medicos)
                .UsingEntity(p => p.ToTable("MedicoPaciente"));

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Diagnostico>()
                    .HasKey(d => d.Id);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Diagnostico)
                .WithOne(d => d.Cita)
                .HasForeignKey<Cita>(c => c.DiagnosticoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                     
        }
    }
}
