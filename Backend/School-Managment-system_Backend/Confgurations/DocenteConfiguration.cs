using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Managment_system_Backend.DTOs;




namespace School_Managment_system_Backend.Confgurations
{
    public class DocenteConfiguration : IEntityTypeConfiguration<Docentes>
    {
        public void Configure(EntityTypeBuilder<Docentes> builder)
        {
            // Configuración de la entidad Docentes
            builder.ToTable("Docentes");
            builder.HasKey(d => d.Id); // Clave primaria
            builder.Property(d => d.Nombre).IsRequired().HasMaxLength(100);
            builder.HasOne(d => d.Grado)
                   .WithMany(g => g.Docentes)
                   .HasForeignKey(d => d.GradoId);

            // Agrega más configuraciones según sea necesario
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }
    }
}
