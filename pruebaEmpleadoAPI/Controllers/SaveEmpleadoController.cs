using pruebaEmpleadoAPI.Application.Interfaces;
using pruebaEmpleadoAPI.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace pruebaEmpleadoAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SaveEmpleadoController : ControllerBase
    {        
		private readonly ISaveEmpleadoApp _saveEmpleadoApp;
		public SaveEmpleadoController(ISaveEmpleadoApp saveEmpleadoApp)
		{
			this._saveEmpleadoApp = saveEmpleadoApp;
		}

		[HttpPost]
		[Route("Save")]
	
		public async Task<IActionResult> SaveEmpleado(EmpleadosDto dto)
		{
			var result = await _saveEmpleadoApp.SaveEmpleado(dto);
			return Ok(result);
		}

		[HttpPost]
		[Route("Update")]

		public async Task<IActionResult> UpdateEmpleado(EmpleadosUpdateDto dto)
		{
			var result = await _saveEmpleadoApp.UpdateEmpleado(dto);
			return Ok(result);
		}

		[HttpGet]
		[Route("GetEmpleados")]

		public async Task<IActionResult> GetEmpleados()
		{
			var result = await _saveEmpleadoApp.GetEmpleado();
			return Ok(result);
		}

		[HttpGet]
		[Route("GetEmpleadosbyId")]

		public async Task<IActionResult> GetEmpleadosbyId(long idEmpleado)
		{
			var result = await _saveEmpleadoApp.GetEmpleadosbyId(idEmpleado);
			return Ok(result);
		}

	}
}

