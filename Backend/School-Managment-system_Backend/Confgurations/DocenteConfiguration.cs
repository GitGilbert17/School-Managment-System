using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.Models;




namespace School_Managment_system_Backend.Confgurations
{
    public class DocenteConfiguration : IEntityTypeConfiguration<Docentes>
    {
        public void Configure(EntityTypeBuilder<Docentes> builder)
        {
            //Vinculacion con la tabla Docentes
            builder.ToTable("Docentes");

            //Clave primaria
            builder.HasKey(d => d.Id);

            //Propiedades con sus tipos de datos y longitudes exactas
            builder.Property(d => d.Nombre)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

            builder.Property(d => d.Apellido)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");  

            builder.Property(d => d.Cedula)
                   .IsRequired()
                   .HasMaxLength(15)
                   .HasColumnType("nvarchar(15)");

            //Restriccion UNIQUE para la cedula

            builder.HasIndex(d => d.Cedula)
                   .IsUnique();

            builder.Property(d => d.Email)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");

            //Restriccion UNIQUE para el email
            builder.HasIndex(d => d.Email)
                   .IsUnique();

            builder .Property(d => d.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnType("nvarchar(15)");

            builder.Property(d => d.Especialidad)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar(50)");

            builder.Property(d => d.FechaContratacion)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(d => d.Activo)
                   .IsRequired()
                   .HasColumnType("bit");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }
    }
}
