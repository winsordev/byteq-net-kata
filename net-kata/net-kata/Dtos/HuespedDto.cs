using Duende.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace net_kata.Dtos
{
    public class HuespedDto
    {
        public int HuespedId { get; set; }
        [Required(ErrorMessage = "Identificación es requerido")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Teléfono es requerido")]
        public string Telefono { get; set; }
    }
}
