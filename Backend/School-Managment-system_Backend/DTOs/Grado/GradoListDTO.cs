namespace School_Managment_system_Backend.DTOs.Grado
{
    public class GradoListDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
