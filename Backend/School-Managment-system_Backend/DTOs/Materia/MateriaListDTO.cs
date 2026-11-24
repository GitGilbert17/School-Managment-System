namespace School_Managment_system_Backend.DTOs.Materia
{
    public class MateriaListDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoMateria { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int DocenteId { get; set; }
        public string NombreDocente { get; set; } = string.Empty;
        public int GradoId { get; set; }
        public string NombreGrado { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}
