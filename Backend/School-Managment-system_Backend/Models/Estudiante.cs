namespace School_Managment_system_Backend.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Cedula { get; set; } // Puede ser null según nuestra BD
        public DateTime FechaNacimiento { get; set; }
        public string? Email { get; set; } // Faltaba el email que diseñamos en SQL
        public string? Telefono { get; set; }
        public int GradoId { get; set; }
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

        // Propiedad de navegación de EF Core (para conectar con la tabla Grados)
        public Grado? Grado { get; set; }
    }
}   