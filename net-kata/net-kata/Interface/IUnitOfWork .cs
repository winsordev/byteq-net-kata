using net_kata.Models;

namespace net_kata.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Huesped> Huespedes { get; }
        IRepository<Habitacion> Habitaciones { get; }
        IRepository<HuespedHabitacion> Reservaciones { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
