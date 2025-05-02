using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPP.Domain.Entities;

namespace SGPP.Domain.Repositories
{
    public interface IProveedorTieneProductoRepository
    {
        Task<IList<ProveedorTieneProducto>> GetAll();
        Task<ProveedorTieneProducto> GetById(int idProveedor, int idProducto);
        Task Create(ProveedorTieneProducto relacion);
        Task Update(ProveedorTieneProducto relacion);
        Task Delete(int idProveedor, int idProducto);
    }
}
