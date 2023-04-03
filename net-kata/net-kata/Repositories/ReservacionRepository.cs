using Microsoft.EntityFrameworkCore;
using net_kata.Data;
using net_kata.Interface;
using net_kata.Models;

namespace net_kata.Repositories
{
    public class ReservacionRepository : IReservacion
    {
        private readonly ApplicationDbContext _context;
        public ReservacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(HuespedHabitacion item)
        {
            _context.Set<HuespedHabitacion>().Add(item);
        }

        public void Delete(int huespedHabitacionId)
        {
            var reservacion = _context.Set<HuespedHabitacion>().Find(huespedHabitacionId);
            _context.Set<HuespedHabitacion>().Remove(reservacion);
        }

        public IEnumerable<HuespedHabitacion> GetAll()
        {
            return _context.Set<HuespedHabitacion>().ToList();
        }

        public HuespedHabitacion GetById(int huespedHabitacionId)
        {
            return _context.Set<HuespedHabitacion>().Find(huespedHabitacionId);
        }

        public void Update(HuespedHabitacion item)
        {
            _context.Set<HuespedHabitacion>().Update(item);
        }
    }
}
