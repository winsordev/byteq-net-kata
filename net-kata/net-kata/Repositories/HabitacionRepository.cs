using Microsoft.EntityFrameworkCore;
using net_kata.Data;
using net_kata.Interface;
using net_kata.Models;

namespace net_kata.Repositories
{
    public class HabitacionRepository : IHabitacion
    {
        private readonly ApplicationDbContext _context;

        public HabitacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Habitacion item)
        {
            _context.Set<Habitacion>().Add(item);
        }

        public void Delete(int habitacionId)
        {
            var habitacion = _context.Set<Habitacion>().Find(habitacionId);
            _context.Set<Habitacion>().Remove(habitacion);
        }

        public IEnumerable<Habitacion> GetAll()
        {
            return _context.Set<Habitacion>().ToList();
        }

        public Habitacion GetById(int habitacionId)
        {
            return _context.Set<Habitacion>().Find(habitacionId);
        }

        public void Update(Habitacion item)
        {
            _context.Set<Habitacion>().Update(item);
        }

        Task<Habitacion> IHabitacion.GetById(int habitacionId)
        {
            throw new NotImplementedException();
        }
    }
}
