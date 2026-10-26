using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
        // Configuración de la entidad Estudiante
        Console.WriteLine("Configuring Estudiante entity...");
        builder.ToTable("Estudiantes");
        builder.HasKey(e => e.Id); // Clave primaria
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100); // Propiedad Nombre requerida con longitud máxima
        builder.HasOne(e => e.grado)
              .WithMany(g => g.Estudiantes)
              .HasForeignKey(e => e.GradoId);
    }
}


protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstudianteConfiguration).Assembly);
    }
    