using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPP.Domain.Entities
{
    public partial class Productos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe escribir una Descripción")]
        [MinLength(4, ErrorMessage = "Descripción debe tener al menos 4 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe escribir una Unidad de medida")]
        [MinLength(2, ErrorMessage = "Unidad de medida debe tener al menos 2 caracteres")]
        public string UnidadDeMedida { get; set; }

        [Required(ErrorMessage = "Debe escribir un Precio unitario")]
        [Range(1, int.MaxValue, ErrorMessage = "Precio unitario debe ser un monto válido")]
        public int PrecioUnitario { get; set; }

        public Productos()
        {
            Descripcion = "";
            UnidadDeMedida = "";
            PrecioUnitario = 1;
        }
    }
}
