using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;

namespace SGPP.Application
{
    public interface IProveedoresService
    {
        Task<IList<Proveedores>> GetAll();
        Task<Proveedores> GetById(int id);
        Task Create(Proveedores proveedor);
        Task Update(Proveedores proveedor);
        Task Delete(int id);
    }
}