using Duende.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace net_kata.Dtos
{
    public class HabitacionDto
    {
        public int HabitacionId { get; set; }
        [Required(ErrorMessage = "Descripción es requerido")]
        public string Descripcion { get; set; }
        public int Piso { get; set; }
        public int Numero { get; set; }
        public bool Disponible { get; set; }
    }
}
