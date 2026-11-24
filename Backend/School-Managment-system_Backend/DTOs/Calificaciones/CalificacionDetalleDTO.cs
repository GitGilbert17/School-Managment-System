namespace School_Managment_system_Backend.DTOs.Calificaciones
{
    public class CalificacionDetalleDTO
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string NombreEstudiante { get; set; } = string.Empty;
        public int MateriaId { get; set; }
        public string NombreMateria { get; set; } = string.Empty;
        public int PeriodoId { get; set; }
        public string NombrePeriodo { get; set; } = string.Empty;
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal NotaFinal{ get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
