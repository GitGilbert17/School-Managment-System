namespace School_Managment_system_Backend.DTOs
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;  
        public string Apellido { get; set; } = string.Empty;
        public int GradoId { get; set; } // Clave foránea apunta al grado del estudiante
        public string cedula { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        // Se asigna la fecha de hoy por defecto al crear el objeto en C#
        public DateOnly FechaInscripcion { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Fecha de inscripción del estudiante

        public string Telefono { get; set; } = string.Empty;

        public bool Activo { get; set; } = true; // Indica si el estudiante está activo o no


    }
}
