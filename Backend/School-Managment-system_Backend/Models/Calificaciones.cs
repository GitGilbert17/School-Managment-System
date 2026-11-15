namespace School_Managment_system_Backend.Models
{
    public class Calificaciones
    {       
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
        public int PeriodoId { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal NotaFinal { get; set; }
        public string? observaciones { get; set; } // Puede ser null según nuestra BD
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public Estudiante? Estudiante { get; set; }
        public Materia? Materia { get; set; }
        public Periodos? Periodo { get; set; }

    }
}
