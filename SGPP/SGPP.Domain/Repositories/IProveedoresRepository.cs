using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPP.Domain.Entities;

namespace SGPP.Domain.Repositories
{
    public interface IProveedoresRepository
    {
        Task<IList<Proveedores>> GetAll();
        Task<Proveedores> GetById(int id);
        Task Create(Proveedores proveedor);
        Task Update(Proveedores proveedor);
        Task Delete(int id);
    }
}
