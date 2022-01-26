using pruebaEmpleadoAPI.Domain.Dto;
using pruebaEmpleadoAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Domain.Interfaces
{
    public interface ISaveEmpleadoRepository
    {
        Task<Result<int>> SaveEmpleadoAsync(EmpleadosDto typification);
        Task<Result<int>> UpdateEmpleadoAsync(EmpleadosUpdateDto typification);
        Task<Result<List<Empleado>>> GetEmpleadoAsync();
        Task<Result<List<Empleado>>> GetEmpleadosbyIdAsync(long idEmpleado);
    }
}
