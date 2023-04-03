namespace net_kata.Dtos
{
    public class HuespedHabitacionDto
    {
        public int HuespedId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool CheckIn { get; set; }
        public bool CheckOut { get; set; }
    }
}
