using Microsoft.EntityFrameworkCore;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;
using SGPP.Infrastructure;

namespace SGPP.Infrastructure.Repositories
{
    public class ProveedorTieneProductoRepository : IProveedorTieneProductoRepository
    {
        private readonly SGPPDbContext _context;

        public ProveedorTieneProductoRepository(SGPPDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ProveedorTieneProducto>> GetAll()
        {
            return await _context.ProveedorTieneProducto.ToListAsync();
        }

        public async Task<ProveedorTieneProducto> GetById(int idProveedor, int idProducto)
        {
            return await _context.ProveedorTieneProducto
                .FirstOrDefaultAsync(p => p.IdProveedor == idProveedor && p.IdProducto == idProducto);
        }

        public async Task Create(ProveedorTieneProducto relacion)
        {
            _context.ProveedorTieneProducto.Add(relacion);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProveedorTieneProducto relacion)
        {
            var relacionActual = await _context.ProveedorTieneProducto.FirstOrDefaultAsync(r => r.IdProveedor == relacion.IdProveedor && r.IdProducto == relacion.IdProducto);

            if (relacionActual != null)
            {
                relacionActual.IdProveedor = relacion.IdProveedor;
                relacionActual.IdProducto = relacion.IdProducto;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int idProveedor, int idProducto)
        {
            var relacion = await _context.ProveedorTieneProducto.FirstOrDefaultAsync(r => r.IdProveedor == idProveedor && r.IdProducto == idProducto);

            if (relacion != null)
            {
                _context.ProveedorTieneProducto.Remove(relacion);
            }

            await _context.SaveChangesAsync();
        }
    }
}
