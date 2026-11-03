using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Data;
using School_Managment_system_Backend.DTOs;

namespace School_Managment_system_Backend.Confgurations;
public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
        // Configuración de la entidad Estudiante
        builder.ToTable("Estudiantes");
        builder.HasKey(e => e.Id); // Clave primaria
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100); // Propiedad Nombre requerida con longitud máxima
        builder.HasOne(e => e.Grado)
              .WithMany(g => g.Estudiantes)
              .HasForeignKey(e => e.GradoId);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EscuelaDbContext).Assembly);
    }
}
    
