using net_kata.Models;

namespace net_kata.Interface
{
    public interface IHabitacion
    {
        void Add(Habitacion item);
        void Update(Habitacion item);
        void Delete(int habitacionId);
        Task<Habitacion> GetById(int habitacionId);
        IEnumerable<Habitacion> GetAll();
    }
}
