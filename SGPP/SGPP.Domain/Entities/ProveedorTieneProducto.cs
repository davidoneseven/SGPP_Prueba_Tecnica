using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPP.Domain.Entities
{
    public partial class ProveedorTieneProducto
    {
        [Required(ErrorMessage = "Debe indicar el Proveedor")]
        [Range(1, int.MaxValue, ErrorMessage = "Proveedor inválido")]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "Debe indicar el Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Producto inválido")]
        public int IdProducto { get; set; }

        public ProveedorTieneProducto()
        {
            IdProveedor = 0;
            IdProducto = 0;
        }
    }
}
