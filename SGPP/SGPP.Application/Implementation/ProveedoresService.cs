using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPP.Application;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;

namespace SGPP.Application.Implementation
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IProveedoresRepository _proveedoresRepository;

        public ProveedoresService(IProveedoresRepository proveedoresRepository)
        {
            _proveedoresRepository = proveedoresRepository;
        }

        public async Task<IList<Proveedores>> GetAll()
        {
            return await _proveedoresRepository.GetAll();
        }

        public async Task<Proveedores> GetById(int id)
        {
            return await _proveedoresRepository.GetById(id);
        }

        public async Task Create(Proveedores proveedor)
        {
            await _proveedoresRepository.Create(proveedor);
        }

        public async Task Update(Proveedores proveedor)
        {
            await _proveedoresRepository.Update(proveedor);
        }

        public async Task Delete(int id)
        {
            await _proveedoresRepository.Delete(id);
        }

    }
}