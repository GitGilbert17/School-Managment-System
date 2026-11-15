namespace School_Managment_system_Backend.Models
{
    public class Grado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Propiedad de navegación de EF Core (para conectar con la tabla Estudiantes)
        public ICollection<Estudiante>? Estudiantes { get; set; }
    }
}
