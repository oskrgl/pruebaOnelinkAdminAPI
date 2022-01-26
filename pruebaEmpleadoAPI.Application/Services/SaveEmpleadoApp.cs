using pruebaEmpleadoAPI.Application.Interfaces;
using pruebaEmpleadoAPI.Domain.Dto;
using pruebaEmpleadoAPI.Domain.Entities;
using pruebaEmpleadoAPI.Domain.Interfaces;
using pruebaEmpleadoAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Application.Services
{
    public class SaveEmpleadoApp : ISaveEmpleadoApp
    {
        private readonly ISaveEmpleadoRepository _saveEmpleadoRepository;

        public SaveEmpleadoApp(ISaveEmpleadoRepository repository)
        {
            this._saveEmpleadoRepository = repository;
        }



        public async Task<Response<int>> SaveEmpleado(EmpleadosDto dto)
        {
            SaveEmpleadoServices _saveEmpleadoService = new SaveEmpleadoServices();
            var result = await _saveEmpleadoService.SaveEmpleadoAsync(_saveEmpleadoRepository, dto);
            return result;
        }
        
        public async Task<Response<int>> UpdateEmpleado(EmpleadosUpdateDto dto)
        {
            SaveEmpleadoServices _updateEmpleadoService = new SaveEmpleadoServices();
            var result = await _updateEmpleadoService.UpdateEmpleadoAsync(_saveEmpleadoRepository, dto);
            return result;
        }

        public async Task<Response<List<Empleado>>> GetEmpleado()
        {
            SaveEmpleadoServices _saveEmpleadoService = new SaveEmpleadoServices();
            return await _saveEmpleadoService.GetEmpleadoAsync(_saveEmpleadoRepository);
        }
        
        public async Task<Response<List<Empleado>>> GetEmpleadosbyId(long idEmpleado)
        {
            SaveEmpleadoServices _saveEmpleadoService = new SaveEmpleadoServices();
            return await _saveEmpleadoService.GetEmpleadosbyIdAsync(_saveEmpleadoRepository, idEmpleado);
        }
    }
}
