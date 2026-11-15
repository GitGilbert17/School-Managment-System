using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Models;
    

namespace School_Managment_system_Backend.Confgurations

{
    public class GradoConfiguration
    {
        public void Configure(EntityTypeBuilder<Grado> builder)
        {
            //Vinculacion con la tabla Grados
            builder.ToTable("Grados");
            //Clave primaria
            builder.HasKey(g => g.Id);
            //Propiedades con sus tipos de datos y longitudes exactas
            builder.Property(g => g.Nombre)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

            builder.Property(g => g.Nivel)
                     .IsRequired()
                     .HasMaxLength(20)
                     .IsUnicode(false)
                     .HasColumnType("nvarchar(20)");

            builder.ToTable(t =>
            t.HasCheckConstraint(
                "CK_Grados_Nivel",
                "Nivel IN ('Primaria', 'Secundaria')"
                )
             );
            
                     

        }

    }
}
