namespace School_Managment_system_Backend.DTOs.Materia
{
    public class MateriaCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string CodigoMateria { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int DocenteId { get; set; }
        public int GradoId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
