using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGPP.Application;
using SGPP.Application.Implementation;
using SGPP.Domain.Entities;

namespace SGPP_API.Controllers
{
    [ApiController]
    [Route("api/abastecimiento")]
    public class ProveedorTieneProductoAPIController : ControllerBase
    {
        private readonly IProveedorTieneProductoService _service;

        public ProveedorTieneProductoAPIController(IProveedorTieneProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Listar()
        {
            var relaciones = await _service.GetAll();

            if (relaciones == null)
            {
                return StatusCode(500, "Failed to retrieve data.");
            }
            else
            {
                return Ok(relaciones);
            }
        }

        [HttpGet("{idProveedor}/{idProducto}")]
        //[Authorize]
        public async Task<IActionResult> Obtener(int idProveedor, int idProducto)
        {
            var abastecimiento = await _service.GetById(idProveedor, idProducto);

            if (abastecimiento == null)
            {
                return StatusCode(500, "Failed to retrieve data.");
            }
            else
            {
                return Ok(abastecimiento);
            }
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Registrar(ProveedorTieneProducto relacion)
        {
            if (relacion == null)
            {
                return BadRequest("Data object is null.");
            }

            await _service.Create(relacion);

            return Ok("Data registered successfully.");
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Actualizar(ProveedorTieneProducto relacion)
        {
            if (relacion == null)
            {
                return BadRequest("Data object is null.");
            }

            await _service.Update(relacion);

            return Ok("Data updated successfully.");
        }

        [HttpDelete("{idProveedor}/{idProducto}")]
        //[Authorize]
        public async Task<IActionResult> Eliminar(int idProveedor, int idProducto)
        {
            if (idProveedor < 1 || idProveedor > int.MaxValue || idProducto < 1 || idProducto > int.MaxValue)
            {
                return BadRequest("Request parameters are out of scope.");
            }

            await _service.Delete(idProveedor, idProducto);

            return Ok("Data deleted successfully.");
        }
    }
}
