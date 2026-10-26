using System;
using Microsoft.EntityFrameworkCore;



namespace School_Managment_system_Backend.DTOs
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }
        // Aquí puedes definir tus DbSets para las entidades de tu base de datos.
        // Por ejemplo:
        // public DbSet<Alumno> Alumnos { get; set; }
        // public DbSet<Curso> Cursos { get; set; }
    }
}
