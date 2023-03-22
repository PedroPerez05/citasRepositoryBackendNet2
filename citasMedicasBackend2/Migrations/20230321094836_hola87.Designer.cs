﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using citasMedicasBackend2.Datos;

#nullable disable

namespace citasMedicasBackend2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230321094836_hola87")]
    partial class hola87
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.Property<int>("MedicosId")
                        .HasColumnType("int");

                    b.Property<int>("PacientesId")
                        .HasColumnType("int");

                    b.HasKey("MedicosId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("MedicoPaciente", (string)null);
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiagnosticoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("MotivoCita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosticoId")
                        .IsUnique();

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Diagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Enfermedad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValoracionEspecialista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosticos");
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Medico", b =>
                {
                    b.HasBaseType("citasMedicasBackend2.Models.Usuario");

                    b.Property<string>("NumColegiado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Paciente", b =>
                {
                    b.HasBaseType("citasMedicasBackend2.Models.Usuario");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.HasOne("citasMedicasBackend2.Models.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("citasMedicasBackend2.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Cita", b =>
                {
                    b.HasOne("citasMedicasBackend2.Models.Diagnostico", "Diagnostico")
                        .WithOne("Cita")
                        .HasForeignKey("citasMedicasBackend2.Models.Cita", "DiagnosticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("citasMedicasBackend2.Models.Medico", "Medico")
                        .WithMany("Citas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("citasMedicasBackend2.Models.Paciente", "Paciente")
                        .WithMany("Citas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Diagnostico");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Medico", b =>
                {
                    b.HasOne("citasMedicasBackend2.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("citasMedicasBackend2.Models.Medico", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Paciente", b =>
                {
                    b.HasOne("citasMedicasBackend2.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("citasMedicasBackend2.Models.Paciente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Diagnostico", b =>
                {
                    b.Navigation("Cita")
                        .IsRequired();
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Medico", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("citasMedicasBackend2.Models.Paciente", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
