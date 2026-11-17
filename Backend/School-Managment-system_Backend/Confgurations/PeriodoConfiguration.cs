using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Models;



namespace School_Managment_system_Backend.Confgurations
{
    public class PeriodoConfiguration
    {
        public void Configure(EntityTypeBuilder<Periodos> builder)
        {
            builder.ToTable("Periodos", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint(
                 "CHK_Fechas_Periodos",
                 "[FechaFin] > [FechaInicio]"
                 
                 );
            
            });
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(p => p.FechaInicio)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.FechaFin)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.Activo)
                    .IsRequired()
                    .HasDefaultValue(true);
        }
    }
}
