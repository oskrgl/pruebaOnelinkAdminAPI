using System;

namespace pruebaEmpleadoAPI.Domain.Dto
{
    public class EmpleadosDto
    {
        public long numIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int isActive { get; set; }
        public int isAdmin { get; set; }
        public int Tipo { get; set; }
        public string Estado { get; set; }
        public string Cargo { get; set; }
    }
}
