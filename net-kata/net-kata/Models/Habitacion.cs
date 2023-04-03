using System.ComponentModel.DataAnnotations;

namespace net_kata.Models
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }
        public string? Descripcion { get; set; }
        public int Piso { get; set; }
        public int Numero { get; set; }
        public bool Disponible { get; set; }
        public ICollection<HuespedHabitacion> Reservacion { get; set; }
    }
}
