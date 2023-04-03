using IdentityModel;
using Microsoft.EntityFrameworkCore;
using net_kata.Data;
using net_kata.Interface;

namespace net_kata.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var result = _entities.AsEnumerable();
            return result;
        }

        public async Task<TEntity>  GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
