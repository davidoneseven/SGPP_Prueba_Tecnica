using Microsoft.EntityFrameworkCore;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;
using SGPP.Infrastructure;

namespace SGPP.Infrastructure.Repositories
{
    public class ProveedoresRepository : IProveedoresRepository
    {
        private readonly SGPPDbContext _context;

        public ProveedoresRepository(SGPPDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Proveedores>> GetAll()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedores> GetById(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Proveedores proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Proveedores proveedor)
        {
            var proveedorActual = await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == proveedor.Id);

            if (proveedorActual != null)
            {
                proveedorActual.Nombre = proveedor.Nombre;
                proveedorActual.Email = proveedor.Email;
                proveedorActual.Direccion = proveedor.Direccion;
                proveedorActual.Telefono = proveedor.Telefono;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);

            if (proveedor != null) {
                _context.Proveedores.Remove(proveedor);
            }

            await _context.SaveChangesAsync();
        }
    }
}
