using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPP.Domain.Entities
{
    public partial class Proveedores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe escribir un Nombre")]
        [MinLength(3, ErrorMessage = "El Nombre debe tener al menos 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe escribir un Correo electrónico")]
        [EmailAddress(ErrorMessage = "Debe ingresar una dirección de correo válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe escribir una Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe escribir un Teléfono")]
        [RegularExpression(@"^\d{8,}$", ErrorMessage = "El Teléfono debe tener al menos 8 dígitos")]
        public string Telefono { get; set; }

        public Proveedores()
        {
            Nombre = "";
            Email = "";
            Direccion = "";
            Telefono = "";
        }

        public Proveedores(string nombre, string email, string direccion, string telefono)
        {
            Nombre = nombre;
            Email = email;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
