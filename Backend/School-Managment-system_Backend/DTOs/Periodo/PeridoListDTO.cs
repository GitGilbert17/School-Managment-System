namespace School_Managment_system_Backend.DTOs.Periodo
{
    public class PeridoListDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; } = true;
    }
}
