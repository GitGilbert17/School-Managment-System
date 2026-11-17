namespace School_Managment_system_Backend.DTOs.Estudiante
{
    public class EstudianteUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int GradoId { get; set; }
        public bool Activo { get; set; } = true;

    }
}
