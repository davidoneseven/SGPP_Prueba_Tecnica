using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGPP.Application;
using SGPP.Domain.Entities;

namespace SGPP_API.Controllers
{
	[ApiController]
	[Route("api/proveedores")]
	public class ProveedoresAPIController : ControllerBase
	{
		private readonly IProveedoresService _proveedoresService;
		
		public ProveedoresAPIController(IProveedoresService proveedoresService)
		{
			_proveedoresService = proveedoresService;
		}

		[HttpGet]
        //[Authorize]
        public async Task<IActionResult> Listar()
		{
			var proveedores = await _proveedoresService.GetAll();

			if (proveedores == null)
			{
				return StatusCode(500, "Failed to retrieve data.");
			}
			else 
			{
                return Ok(proveedores);
            }
		}

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Obtener(int id)
        {
            var proveedor = await _proveedoresService.GetById(id);

            if (proveedor == null)
            {
                return StatusCode(500, "Failed to retrieve data.");
            }
            else
            {
                return Ok(proveedor);
            }
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Registrar(Proveedores proveedor)
		{
			if (proveedor == null) 
			{
				return BadRequest("Data object is null.");
			}

			await _proveedoresService.Create(proveedor);

			return Ok("Data registered successfully.");
		}

		[HttpPut]
        //[Authorize]
        public async Task<IActionResult> Actualizar(Proveedores proveedor)
		{
            if (proveedor == null)
            {
                return BadRequest("Data object is null.");
            }

            await _proveedoresService.Update(proveedor);

            return Ok("Data updated successfully.");
        }

		[HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Eliminar(int id)
		{
            if (id < 1 || id > int.MaxValue)
            {
                return BadRequest("Request parameters are out of scope.");
            }

            await _proveedoresService.Delete(id);

            return Ok("Data deleted successfully.");
        }
	}
}
