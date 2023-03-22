using citasMedicasBackend2.Datos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using citasMedicasBackend2.Configurations;
using citasMedicasBackend2.Services;
using citasMedicasBackend2.Repositories;
using citasMedicasBackend2.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing=>routing.LowercaseUrls=true); //convertir todas las url a minusculas
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<DiagnosticoRepository>();
builder.Services.AddScoped<DiagnosticoService>();
builder.Services.AddScoped<CitaRepository>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
