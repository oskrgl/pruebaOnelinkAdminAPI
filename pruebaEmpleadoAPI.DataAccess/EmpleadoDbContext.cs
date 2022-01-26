using pruebaEmpleadoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace pruebaEmpleadoAPI.DataAccess
{
    /// <summary>
    /// Represents the Empleados database context
    /// </summary>
    public class EmpleadoDbContext : DbContext
    {
        /// <summary>
        /// Represents the Users table
        /// </summary>
        public DbSet<Empleado>empleado { get; set; }
        /// <summary>
        /// Creates an instance of <see cref="EmpleadoDbContext"/>
        /// </summary>
        /// <param name="options">Context options</param>
        public EmpleadoDbContext(DbContextOptions<EmpleadoDbContext> options) : base(options)
        {
        }
    }
}
