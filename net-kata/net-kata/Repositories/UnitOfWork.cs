using net_kata.Data;
using net_kata.Interface;
using net_kata.Models;

namespace net_kata.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly IRepository<Huesped> _HuespedRepository;
        private readonly IRepository<Habitacion> _HabitacionRepository;
        private readonly IRepository<HuespedHabitacion> _ReservacionRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepository<Huesped> Huespedes => _HuespedRepository ?? new BaseRepository<Huesped>(_context);
        public IRepository<Habitacion> Habitaciones => _HabitacionRepository ?? new BaseRepository<Habitacion>(_context);
        public IRepository<HuespedHabitacion> Reservaciones => _ReservacionRepository ?? new BaseRepository<HuespedHabitacion>(_context);

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
