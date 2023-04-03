using net_kata.Models;

namespace net_kata.Interface
{
    public interface IHuesped
    {
        void Add(Huesped item);
        void Update(Huesped item);
        void Delete(int huespedId);
        Huesped GetById(int huespedId);
        IEnumerable<Huesped> GetAll();
    }
}
