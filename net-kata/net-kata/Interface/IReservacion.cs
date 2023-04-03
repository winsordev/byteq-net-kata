using net_kata.Models;

namespace net_kata.Interface
{
    public interface IReservacion
    {
        void Add(HuespedHabitacion item);
        void Update(HuespedHabitacion item);
        void Delete(int huespedHabitacionId);
        HuespedHabitacion GetById(int huespedHabitacionId);
        IEnumerable<HuespedHabitacion> GetAll();
    }
}
