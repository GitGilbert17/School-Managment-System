using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Models;

namespace School_Managment_system_Backend.Configurations
{
    public class CalificacionConfiguration : IEntityTypeConfiguration<Calificaciones>
    {
        public void Configure(EntityTypeBuilder<Calificaciones> builder)
        {
            builder.ToTable("Calificaciones", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint(
                    "CHK_Nota1",
                    "[Nota1] BETWEEN 0 AND 100"
                );
                tableBuilder.HasCheckConstraint(
                    "CHK_Nota2",
                    "[Nota2] BETWEEN 0 AND 100"
                );
                tableBuilder.HasCheckConstraint(
                    "CHK_Nota3",
                    "[Nota3] BETWEEN 0 AND 100"
                );
                tableBuilder.HasCheckConstraint(
                    "CHK_NotaFinal",
                    "[NotaFinal] BETWEEN 0 AND 100"
                );
            });

            builder.HasKey(c => c.Id);

            builder.Property(c => c.EstudianteId)
                   .IsRequired();

            builder.Property(c => c.MateriaId)
                   .IsRequired();

            builder.Property(c => c.PeriodoId)
                   .IsRequired();

            builder.Property(c => c.Nota1)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Nota2)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Nota3)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            builder.Property(c => c.NotaFinal)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            builder.Property(c => c.observaciones)
                   .HasMaxLength(255)
                   .IsUnicode(false);

            builder.Property(c => c.FechaRegistro)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            // Evita duplicar la calificación del mismo estudiante en la misma materia y período
            builder.HasIndex(c => new { c.EstudianteId, c.MateriaId, c.PeriodoId })
                   .IsUnique()
                   .HasDatabaseName("UQ_Estudiante_Materia_Periodo");

            // FK -> Estudiantes
            builder.HasOne(c => c.Estudiante)
                   .WithMany() // O .WithMany(e => e.Calificaciones) si agregas esa colección en Estudiante
                   .HasForeignKey(c => c.EstudianteId)
                   .HasConstraintName("FK_Calificaciones_Estudiantes")
                   .OnDelete(DeleteBehavior.Restrict);

            // FK -> Materias
            builder.HasOne(c => c.Materia)
                   .WithMany() // O .WithMany(m => m.Calificaciones) si agregas esa colección en Materia
                   .HasForeignKey(c => c.MateriaId)
                   .HasConstraintName("FK_Calificaciones_Materias")
                   .OnDelete(DeleteBehavior.Restrict);

            // FK -> Periodos
            builder.HasOne(c => c.Periodo)
                   .WithMany() // O .WithMany(p => p.Calificaciones) si agregas esa colección en Periodo
                   .HasForeignKey(c => c.PeriodoId)
                   .HasConstraintName("FK_Calificaciones_Periodos")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}