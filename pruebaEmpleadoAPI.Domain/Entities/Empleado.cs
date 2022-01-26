using System.ComponentModel.DataAnnotations;

namespace pruebaEmpleadoAPI.Domain.Entities
{
    public class Empleado
    {
        [Key]
        public long id { get; set; }
        public long num_identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string username { get; set; }
        public int is_active { get; set; }
        public int is_admin { get; set; }
        public int tipo { get; set; }
        public string estado { get; set; }
        public System.DateTime created { get; set; }
        public string cargo { get; set; }
    }
}
