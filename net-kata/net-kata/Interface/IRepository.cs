namespace net_kata.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
