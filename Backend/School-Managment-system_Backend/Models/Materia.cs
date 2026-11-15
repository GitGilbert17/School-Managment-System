using System.Runtime.CompilerServices;

namespace School_Managment_system_Backend.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoMateria { get; set; } = string.Empty;
        public int DocenteId { get; set; }
        public int Creditos { get; set; }
        public int GradoId { get; set; }

        public bool Activo { get; set; } = true;

        // Propiedades de navegación
        public Docentes? Docente { get; set; }
        public Grado? Grado { get; set; }

    }
}
