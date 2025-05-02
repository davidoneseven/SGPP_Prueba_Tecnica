using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGPP.Application;
using SGPP.Application.Implementation;
using SGPP.Domain.Entities;

namespace SGPP_API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosAPIController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosAPIController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Listar()
        {
            var productos = await _productosService.GetAll();

            if (productos == null)
            {
                return StatusCode(500, "Failed to retrieve data.");
            }
            else
            {
                return Ok(productos);
            }
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> Obtener(int id)
        {
            var producto = await _productosService.GetById(id);

            if (producto == null)
            {
                return StatusCode(500, "Failed to retrieve data.");
            }
            else
            {
                return Ok(producto);
            }
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Registrar(Productos producto)
        {
            if (producto == null)
            {
                return BadRequest("Data object is null.");
            }

            await _productosService.Create(producto);

            return Ok("Data registered successfully.");
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Actualizar(Productos producto)
        {
            if (producto == null)
            {
                return BadRequest("Data object is null.");
            }

            await _productosService.Update(producto);

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

            await _productosService.Delete(id);

            return Ok("Data deleted successfully.");
        }
    }
}
