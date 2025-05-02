using Microsoft.EntityFrameworkCore;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;
using SGPP.Infrastructure;

namespace SGPP.Infrastructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly SGPPDbContext _context;

        public ProductosRepository(SGPPDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Productos>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Productos> GetById(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Productos producto)
        {
            var productoActual = await _context.Productos.FirstOrDefaultAsync(p => p.Id == producto.Id);

            if (productoActual != null)
            {
                productoActual.Descripcion = producto.Descripcion;
                productoActual.UnidadDeMedida = producto.UnidadDeMedida;
                productoActual.PrecioUnitario = producto.PrecioUnitario;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
        }
    }
}
