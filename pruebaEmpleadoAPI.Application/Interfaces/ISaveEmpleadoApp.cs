using pruebaEmpleadoAPI.Domain.Dto;
using pruebaEmpleadoAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Application.Interfaces
{
    public interface ISaveEmpleadoApp
    {
        Task<Response<int>> SaveEmpleado(EmpleadosDto dto);
        Task<Response<int>> UpdateEmpleado(EmpleadosUpdateDto dto);
        Task<Response<List<Empleado>>> GetEmpleado();
        Task<Response<List<Empleado>>> GetEmpleadosbyId(long idEmpleado);

    }
}
