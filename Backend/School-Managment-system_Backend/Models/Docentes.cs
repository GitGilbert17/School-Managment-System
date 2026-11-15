namespace School_Managment_system_Backend.Models
{
    public class Docentes
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

        // Propiedad de navegación opcional para cuando mapeemos Materias
        // public ICollection<Materia> Materias { get; set; } = new List<Materia>();
    }
}
