using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPP.Domain.Entities;

namespace SGPP.Domain.Repositories
{
    public interface IProductosRepository
    {
        Task<IList<Productos>> GetAll();
        Task<Productos> GetById(int id);
        Task Create(Productos producto);
        Task Update(Productos producto);
        Task Delete(int id);
    }
}
