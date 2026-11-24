namespace School_Managment_system_Backend.DTOs.Calificaciones
{
    public class CalificacionCreateDTO
    {
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public int PeriodoId { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal NotaFinal { get; set; }
        public string? Observaciones { get; set; }
    }
}
