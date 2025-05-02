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
    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public async Task<IList<Productos>> GetAll()
        {
            return await _productosRepository.GetAll();
        }

        public async Task<Productos> GetById(int id)
        {
            return await _productosRepository.GetById(id);
        }

        public async Task Create(Productos producto)
        {
            await _productosRepository.Create(producto);
        }

        public async Task Update(Productos producto)
        {
            await _productosRepository.Update(producto);
        }

        public async Task Delete(int id)
        {
            await _productosRepository.Delete(id);
        }

    }
}