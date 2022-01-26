using pruebaEmpleadoAPI.Domain.Dto;
using pruebaEmpleadoAPI.Domain.Entities;
using pruebaEmpleadoAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Domain.Services
{
    public class SaveEmpleadoServices
    {
        public async Task<Response<int>> SaveEmpleadoAsync(ISaveEmpleadoRepository _repository, EmpleadosDto dto)
        {
            Response<int> response = new Response<int>();
            var result = await _repository.SaveEmpleadoAsync(dto);
            if(result.result > 0)
            {
                response.data = result.result;
                response.message = "Empleado saved sucessfull";
                response.status = true;
                return response;
            }
           
            response.data = 0;
            response.message = "The store procedure has returned error code";
            response.status = false;
            return response;           
        }
        public async Task<Response<int>> UpdateEmpleadoAsync(ISaveEmpleadoRepository _repository, EmpleadosUpdateDto dto)
        {
            Response<int> response = new Response<int>();
            var result = await _repository.UpdateEmpleadoAsync(dto);
            if(result.result > 0)
            {
                response.data = result.result;
                response.message = "Empleado saved sucessfull";
                response.status = true;
                return response;
            }
           
            response.data = 0;
            response.message = "The store procedure has returned error code";
            response.status = false;
            return response;           
        }

        public async Task<Response<List<Empleado>>> GetEmpleadoAsync(ISaveEmpleadoRepository _repository)
        {
            Response<List<Empleado>> response = new Response<List<Empleado>>();
            var result = await _repository.GetEmpleadoAsync();
            if (result.result != null)
            {
                response.status = true;
                response.message = "Data obtenida correctamente";
                response.data = result.result;
                return response;
            }
            else
            {
                response.status = false;
                response.message = result.message;
                response.data = null;
                return response;
            }
        }

        public async Task<Response<List<Empleado>>> GetEmpleadosbyIdAsync(ISaveEmpleadoRepository _repository, long idEmpleado)
        {
            Response<List<Empleado>> response = new Response<List<Empleado>>();
            var result = await _repository.GetEmpleadosbyIdAsync(idEmpleado);
            if (result.result != null)
            {
                response.status = true;
                response.message = "Data obtenida correctamente";
                response.data = result.result;
                return response;
            }
            else
            {
                response.status = false;
                response.message = result.message;
                response.data = null;
                return response;
            }
        }
    }
}
