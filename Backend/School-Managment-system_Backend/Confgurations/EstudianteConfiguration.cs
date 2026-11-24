using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Models;


namespace School_Managment_system_Backend.Confgurations;
public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
            //Nombre de la tabla en SQL
        builder.ToTable("Estudiantes");

        //Clave primaria
        builder.HasKey(e => e.Id);

        //Propiedades con sus tipos de datos y longitudes exactas
        builder.Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("nvarchar(50)");

        builder.Property(e => e.Apellido)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("nvarchar(50)");

        //Cedula (Unique permitiendo nulos)
        builder.Property(e => e.Cedula)
               .HasMaxLength(15)
               .HasColumnType("nvarchar(15)");

        builder.HasIndex(e => e.Cedula)
                .IsUnique()
                .HasFilter("[Cedula] IS NOT NULL"); // Permitir nulos en la restricción UNIQUE

        //Fecha de nacimiento 
        builder.Property(e => e.FechaNacimiento)
               .IsRequired()
               .HasColumnType("date");

        //Email (Unique permitiendo nulos)
        builder.Property(e => e.Email)
               .HasMaxLength(100)
               .HasColumnType("nvarchar(100)");

        builder.HasIndex(e => e.Email)
                .IsUnique()
                .HasFilter("[Email] IS NOT NULL"); // Permitir nulos en la restricción UNIQUE

        //Telefono
        builder.Property(e => e.Telefono)
               .HasMaxLength(15)
               .HasColumnType("nvarchar(15)");

        //GradoId (FK)
        builder.Property(e => e.GradoId)
               .IsRequired();

        //Fecha de inscripcion
        builder.Property(e => e.FechaInscripcion)
               .IsRequired()
               .HasColumnType("date")
               .HasDefaultValueSql("GETDATE()");

        //Activo(Por defecto true o 1)
        builder.Property(e => e.Activo)
               .IsRequired()
               .HasDefaultValue(true);

        //Relacion con Grado (uno a muchos)
        builder.HasOne(e => e.Grado)
               .WithMany(g => g.Estudiantes)
               .HasForeignKey(e => e.GradoId)
               .OnDelete(DeleteBehavior.Restrict); // Evitar borrado en cascada para proteger datos

    }
}
    
