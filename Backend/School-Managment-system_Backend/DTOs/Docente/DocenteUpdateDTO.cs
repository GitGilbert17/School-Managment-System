namespace School_Managment_system_Backend.DTOs.Docente
{
    public class DocenteUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
    }
}
