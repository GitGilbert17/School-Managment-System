using School_Managment_system_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;




namespace School_Managment_system_Backend.Confgurations
{
    public class MateriaConfiguration
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materias", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint(
                    "CK_Materias_Creditos",
                    "[Creditos] > 0"
                  );
            });

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nombre)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");
            
            builder.Property(m => m.CodigoMateria)
                   .IsRequired()
                   .HasMaxLength(15)
                   .IsUnicode(false);

            builder.HasIndex(m => m.CodigoMateria)
                   .IsUnique()
                   .HasDatabaseName("UQ_Materias_CodigoMateria");

            builder.Property(m => m.Creditos)
                   .IsRequired();

            builder.Property(m => m.DocenteId)
                   .IsRequired();

            builder.Property(m => m.GradoId)
                    .IsRequired();

            builder.Property(m => m.Activo)
                   .IsRequired()
                   .HasDefaultValue(true);

            // Configuración de la relación con la entidad Docentes
            builder.HasOne(m => m.Docente)
                .WithMany()
                  .HasForeignKey(m => m.DocenteId)
                  .HasConstraintName("FK_Materias_Docentes")
                     .OnDelete(DeleteBehavior.Restrict);

            // Relación con Grado (FK_Materias_Grados)
            builder.HasOne(m => m.Grado)
                   .WithMany() 
                   .HasForeignKey(m => m.GradoId)
                   .HasConstraintName("FK_Materias_Grados")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
