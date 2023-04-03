using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_kata.Models
{
    public class HuespedHabitacion
    {
        [ForeignKey("Huesped")]
        public int HuespedId { get; set; }
        public virtual Huesped Huesped { get; set; }

        [ForeignKey("Habitacion")]
        public int HabitacionId { get; set; }
        public virtual Habitacion Habitaciones { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool CheckIn { get; set; }
        public bool CheckOut { get; set; }
    }
}

