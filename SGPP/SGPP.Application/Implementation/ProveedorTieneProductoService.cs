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
    public class ProveedorTieneProductoService : IProveedorTieneProductoService
    {
        private readonly IProveedorTieneProductoRepository _proveedorTieneProductoRepository;

        public ProveedorTieneProductoService(IProveedorTieneProductoRepository proveedorTieneProductoRepository)
        {
            _proveedorTieneProductoRepository = proveedorTieneProductoRepository;
        }

        public async Task<IList<ProveedorTieneProducto>> GetAll()
        {
            return await _proveedorTieneProductoRepository.GetAll();
        }

        public async Task<ProveedorTieneProducto> GetById(int idProveedor, int idProducto)
        {
            return await _proveedorTieneProductoRepository.GetById(idProveedor, idProducto);
        }

        public async Task Create(ProveedorTieneProducto relacion)
        {
            await _proveedorTieneProductoRepository.Create(relacion);
        }

        public async Task Update(ProveedorTieneProducto relacion)
        {
            await _proveedorTieneProductoRepository.Update(relacion);
        }

        public async Task Delete(int idProveedor, int idProducto)
        {
            await _proveedorTieneProductoRepository.Delete(idProveedor,idProducto);
        }

    }
}