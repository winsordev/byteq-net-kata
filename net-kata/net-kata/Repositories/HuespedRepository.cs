using Microsoft.EntityFrameworkCore;
using net_kata.Data;
using net_kata.Interface;
using net_kata.Models;

namespace net_kata.Repositories
{
    public class HuespedRepository : IHuesped
    {
        private readonly ApplicationDbContext _context;

        public HuespedRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Huesped item)
        {
            _context.Set<Huesped>().Add(item);
        }

        public void Delete(int huespedId)
        {
            var huesped = _context.Set<Huesped>().Find(huespedId);
            _context.Set<Huesped>().Remove(huesped);
        }

        public IEnumerable<Huesped> GetAll()
        {
            return _context.Set<Huesped>().ToList();
        }

        public Huesped GetById(int huespedId)
        {
            return _context.Set<Huesped>().Find(huespedId);
        }

        public void Update(Huesped item)
        {
            _context.Set<Huesped>().Update(item);
        }
    }
}
